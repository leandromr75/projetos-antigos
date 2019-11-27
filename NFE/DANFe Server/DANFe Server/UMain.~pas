unit UMain;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  Menus, ComCtrls, ToolWin, ExtCtrls, Db, DbTables, DBITypes, ImgList,
  Buttons, StdCtrls, xmldom, XMLIntf, msxmldom, XMLDoc, ShellApi, Grids, DBGrids, Utils,
  IdBaseComponent, IdComponent, IdTCPConnection, IdTCPClient,
  IdMessageClient, IdSMTP, IdMessage, AppEvnts, IdSSLOpenSSL, IdIOHandler,
  IdIOHandlerSocket, QRPDFFilt, gtXportIntf, gtQRXportIntf, gtClasses,
  gtCstDocEng, gtCstPlnEng, gtCstPDFEng, gtPDFEng, QuickRpt, Provider,
  Xmlxform;


const
 wm_IconMessage = wm_User;

type
  TFMain = class(TForm)
    tmBusca: TTimer;
    btMonitor: TButton;
    stBarra: TStatusBar;
    lvArquivos: TListBox;
    cbVias: TComboBox;
    Label1: TLabel;
    Label2: TLabel;
    Button1: TButton;

    msgEmail: TIdMessage;
    Button2: TButton;
    ApplicationEvents1: TApplicationEvents;

    smtpEnviaMailTeste: TIdSMTP;
    smtpEnviaXML: TIdSMTP;

    popmnuTrayIcon: TPopupMenu;
    Cd1: TMenuItem;
    Desabilitar1: TMenuItem;
    N1: TMenuItem;
    Encerrar1: TMenuItem;
    Envioautomticodeemail1: TMenuItem;
    sslSocket: TIdSSLIOHandlerSocket;
    pdfEngine: TgtPDFEngine;
    pdfExport: TgtQRExportInterface;

    procedure doPrintEventoCancNFe(path, fileName : String; nVias : integer);
    procedure doPrintCCe(path, fileName : String; nVias : integer);
    procedure doPrintNFe(path, fileName : String; nVias : integer);
    procedure doPrintCancNFe(path, fileName : String; nVias : integer);
    procedure FormCreate(Sender: TObject);
    procedure FormCloseQuery(Sender: TObject; var CanClose: Boolean);
    procedure FormDestroy(Sender: TObject);
    procedure btMonitorClick(Sender: TObject);
    procedure tmBuscaTimer(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure ApplicationEvents1Exception(Sender: TObject; E: Exception);
    procedure smtpEnviaXMLWorkEnd(Sender: TObject; AWorkMode: TWorkMode);
    procedure Cd1Click(Sender: TObject);
    procedure Encerrar1Click(Sender: TObject);

  private
    { Private declarations }
    _Utils: NFEUtils;
    Printing : Boolean;
    ClosedByButton : Boolean;
    IconData: TNotifyIconData;
    procedure CriaTrayIcon;
    procedure IncluiTrayIcon(Sender: TObject);
    procedure RestauraTrayIcon;
    procedure GerarPDF(report:TQuickRep; nomeArqPDF :string);
  public
    { Public declarations }
        IniFileName : String;
    procedure WndProc(var Msg : TMessage); override;
    function GetUtils: NFEUtils;
    procedure EnviaXMLEmail(report : TQuickRep; path, fileName, dest, subject : String; body : TStringList; teste : Boolean);
    property Utils: NFEUtils read GetUtils;
  end;

var
  FMain: TFMain;

implementation

{$R *.DFM}

uses
 DateUtils, Variants, relatorioDANFE, relatorioEventoCCe, relatorioEventoCancNFe, Math, UConfig;

procedure TFMain.FormCreate(Sender: TObject);
var
  nomeArquivo :  String;
begin
  {arquivo de configuraçao}
  IniFileName := ExtractFilePath(Application.ExeName) + 'danfe.ini';
  {Barra de tarefas.}
  CriaTrayIcon;
  IncluiTrayIcon(nil);
  Printing := false;
  ClosedByButton := false;

  if( not TTConfig.ExisteConfig ) then
  begin
    nomeArquivo := ChangeFileExt(Application.Exename, '.erro.log');
    NFeUtils.GravaLog('Erro ao ler arquivo de Configuração. '+IniFileName+' não encontrado.',nomeArquivo);
  end;

  TTConfig.LerConfig;
  cbVias.ItemIndex := UConfig.ConfigNumCopias - 1;

end;

procedure TFMain.WndProc(Var Msg : TMessage);
var
  p : TPoint;
begin
  case Msg.Msg of
    WM_USER + 1:
      case Msg.lParam of

        WM_LBUTTONDBLCLK: RestauraTrayIcon;

        WM_RBUTTONDOWN:
        begin
           SetForegroundWindow(Handle);
           GetCursorPos(p);
           popmnuTrayIcon.Popup(p.x, p.y);
           PostMessage(Handle, WM_NULL, 0, 0);
        end;

      end;
  end;
  inherited;
end;

procedure TFMain.CriaTrayIcon;
begin
  IconData.cbSize := sizeof(IconData);
  IconData.Wnd := Handle;
  IconData.uID := 100;
  IconData.uFlags := NIF_MESSAGE + NIF_ICON + NIF_TIP;
  IconData.uCallbackMessage := WM_USER + 1;
  IconData.hIcon := Application.Icon.Handle;
  StrPCopy(IconData.szTip, Application.Title);
end;

procedure TFMain.IncluiTrayIcon(Sender: TObject);
begin
  Shell_NotifyIcon(NIM_ADD, @IconData);
  Self.Hide;
  ShowWindow(Application.Handle, SW_HIDE);
  Application.ShowMainForm := false;
end;

procedure TFMain.RestauraTrayIcon;
begin
  ShowWindow(Application.Handle, SW_SHOW);
  Self.Show;
  Application.BringToFront;
end;

procedure TFMain.FormCloseQuery(Sender: TObject; var CanClose: Boolean);
begin
  CanClose := ClosedByButton;
  if(CanClose)then
    Shell_NotifyIcon(NIM_DELETE, @IconData)
  else
    IncluiTrayIcon(nil);
end;

procedure TFMain.FormDestroy(Sender: TObject);
begin
//  Shell_NotifyIcon(NIM_DELETE, @IconData);//Retira icon da tray
end;

procedure TFMain.btMonitorClick(Sender: TObject);
begin
  tmBusca.Enabled := not tmBusca.Enabled;
  if(tmBusca.Enabled) then
  begin
    stBarra.SimpleText := 'Monitorando';
    //btMonitor.Caption := 'Desabilitar';
    Desabilitar1.Caption := 'Desabilitar';

   end
  else
  begin
    stBarra.SimpleText := 'Parado';
    //btMonitor.Caption := 'Habilitar';
    Desabilitar1.Caption := 'Habilitar';
  end;
end;

procedure TFMain.tmBuscaTimer(Sender: TObject);
var
  nomeArquivo : String;
begin
  Utils.AtualizaFilaImpressao(lvArquivos, ExtractFilePath(Application.ExeName)+'PrintBox\', '*.xml');
  if((not Printing) and (lvArquivos.Count > 0))then
  begin
    Printing := true;
    nomeArquivo := lvArquivos.Items[0];

//   verificar se existe algum arquivo com as palavras
    if Pos('procEventoCancNFe',nomeArquivo) >0 then
      doPrintEventoCancNFe(ExtractFilePath(Application.ExeName)+'PrintBox\', nomeArquivo ,cbVias.ItemIndex + 1)
    else if Pos('procCCe',nomeArquivo) >0 then
      doPrintCCe(ExtractFilePath(Application.ExeName)+'PrintBox\', nomeArquivo ,cbVias.ItemIndex + 1)
    else if Pos('CancNFe',nomeArquivo) >0 then
      doPrintCancNFe(ExtractFilePath(Application.ExeName)+'PrintBox\', nomeArquivo ,cbVias.ItemIndex + 1)
    else
      doPrintNFe(ExtractFilePath(Application.ExeName)+'PrintBox\', nomeArquivo ,cbVias.ItemIndex + 1);

  end;
end;


procedure TFMain.doPrintEventoCancNFe(path, fileName : String; nVias : integer);
var
  TStBody : TStringList;
  existemDados, enviaEmail : Boolean;
  dirPDF, nomeArqPDF, txtFileName : String;
  EventoCancNFeREL: TEventoCancNFeREL;
  dadosComplementares : TStringList;
begin
  enviaEmail := false;
  existemDados := false;
  EventoCancNFeREL := TEventoCancNFeREL.Create(Application);
  dadosComplementares := TStringList.Create;
  try

    //setar origem de dados
    EventoCancNFeREL.XTRProcCancNFe.XMLDataFile  := path + fileName;

    //verificar se existe TXT com dados complementares
    txtFileName := StringReplace(fileName, '.xml','.txt',[rfReplaceAll,rfIgnoreCase]);
    //se existir o arquivo .txt
    existemDados :=  FileExists(path+txtFileName );

    if(existemDados)then
    begin
       //1 item por linha
       //destRazao, destEnd, destBairro, destCEP, destMun, destFone, destUF, destIE : String;
       //emitRazao, emitEnd, emitBairro, emitCEP, emitMun, emitFone, emitUF, emitIE : String;
       dadosComplementares.LoadFromFile(path+txtFileName);

       EventoCancNFeREL.destRazao := dadosComplementares[0];
       EventoCancNFeREL.destEnd := dadosComplementares[1];
       EventoCancNFeREL.destBairro := dadosComplementares[2];
       EventoCancNFeREL.destCEP := dadosComplementares[3];
       EventoCancNFeREL.destMun := dadosComplementares[4];
       EventoCancNFeREL.destFone := dadosComplementares[5];
       EventoCancNFeREL.destUF := dadosComplementares[6];
       EventoCancNFeREL.destIE := dadosComplementares[7];

       EventoCancNFeREL.emitRazao := dadosComplementares[8];
       EventoCancNFeREL.emitEnd := dadosComplementares[9];
       EventoCancNFeREL.emitBairro := dadosComplementares[10];
       EventoCancNFeREL.emitCEP := dadosComplementares[11];
       EventoCancNFeREL.emitMun := dadosComplementares[12];
       EventoCancNFeREL.emitFone := dadosComplementares[13];
       EventoCancNFeREL.emitUF := dadosComplementares[14];
       EventoCancNFeREL.emitIE := dadosComplementares[15];

       EventoCancNFeREL.nnf := dadosComplementares[16];
       EventoCancNFeREL.serie := dadosComplementares[17];
    end;

    EventoCancNFeREL.QREventoCancNFe.PrinterSettings.Copies := nVias;
    EventoCancNFeREL.QREventoCancNFe.Prepare;

    if (ConfigImprimir) then
    begin
      EventoCancNFeREL.QREventoCancNFe.Print;
    end;

    if (ConfigGerarPDF) then
    begin
       dirPDF := ExtractFilePath(Application.ExeName)+'pdf\';
       nomeArqPDF := dirPDF + StringReplace(filename, '.XML','.PDF', [rfReplaceAll, rfIgnoreCase]);
       GerarPDF(EventoCancNFeREL.QREventoCancNFe, nomeArqPDF);
    end;

    enviaEmail := (assigned(EventoCancNFeREL)) and
                  (assigned(EventoCancNFeREL.cdsProcCancNFe)) and
                  (Pos('@', EventoCancNFeREL.cdsProcCancNFeemailDest.AsString) > 0);

    //somente será possivel fazer o envio do email se o txt de dados complementares existir
    if existemDados and enviaEmail and ConfigEnvioAutomatico then
    begin

      TStBody := TStringList.Create;
      TStBody.Add('Esta mensagem refere-se a Nota Fiscal Eletrônica Nacional de Número/Série ' + EventoCancNFeREL.nnf +'/'+ EventoCancNFeREL.serie +' emitida para: '+EventoCancNFeREL.destRazao);
      TStBody.Add('Razão Social: ' + EventoCancNFeREL.emitRazao );
      TStBody.Add('Chave de acesso: ' + EventoCancNFeREL.cdsProcCancNFeinfEvento_chNFe.AsString      );
      TStBody.Add('Protocolo: ' + EventoCancNFeREL.cdsProcCancNFenProtAutorizacao.AsString      );
      TStBody.Add('Para verificar a autorização da SEFAZ referente à nota acima mencionada, acesse o site http://www.nfe.fazenda.gov.br/portal     ');
      TStBody.Add('');
      TStBody.Add('Este e-mail foi criado pelo sistema Open NFe');
      TStBody.Add('http://www.rochadigital.com.br                                                                                                 ');
      TStBody.Add('Envio automático. Favor não responder este e-mail.');


      EnviaXMLEmail(EventoCancNFeREL.QREventoCancNFe, path, fileName,
                EventoCancNFeREL.cdsProcCancNFeemailDest.AsString,
                'NFe '+ EventoCancNFeREL.cdsProcCancNFeinfEvento_chNFe.AsString,
                TStBody, false);
    end;

  finally
    EventoCancNFeREL.Free;
    dadosComplementares.Free;

    if(FileExists(path+txtFileName))then
       DeleteFile(path+txtFileName);
    if not (existemDados and enviaEmail and ConfigEnvioAutomatico) then
    begin
      if(FileExists(path+fileName))then
         DeleteFile(path+fileName);
      Printing := false;
    end;
  end;
end;

procedure TFMain.doPrintCCe(path, fileName : String; nVias : integer);
var
  TStBody : TStringList;
  existemDados, enviaEmail : Boolean;
  dirPDF, nomeArqPDF, txtFileName : String;
  EventoCCeREL: TEventoCCeREL;
  dadosComplementares : TStringList;
begin
  enviaEmail := false;
  existemDados := false;
  EventoCCeREL := TEventoCCeREL.Create(Application);
  dadosComplementares := TStringList.Create;
  try

     //setar origem dos dados
      EventoCCeREL.XTRProcCCe.XMLDataFile  := path + fileName;
      
    //verificar se existe TXT com dados complementares
    txtFileName := StringReplace(fileName, '.xml','.txt',[rfReplaceAll,rfIgnoreCase]);
    //se existir o arquivo .txt
    existemDados :=  FileExists(path+txtFileName );

    if(existemDados)then
    begin
       //1 item por linha
       //destRazao, destEnd, destBairro, destCEP, destMun, destFone, destUF, destIE : String;
       //emitRazao, emitEnd, emitBairro, emitCEP, emitMun, emitFone, emitUF, emitIE : String;
       dadosComplementares.LoadFromFile(path+txtFileName);

       EventoCCeREL.destRazao := dadosComplementares[0];
       EventoCCeREL.destEnd := dadosComplementares[1];
       EventoCCeREL.destBairro := dadosComplementares[2];
       EventoCCeREL.destCEP := dadosComplementares[3];
       EventoCCeREL.destMun := dadosComplementares[4];
       EventoCCeREL.destFone := dadosComplementares[5];
       EventoCCeREL.destUF := dadosComplementares[6];
       EventoCCeREL.destIE := dadosComplementares[7];

       EventoCCeREL.emitRazao := dadosComplementares[8];
       EventoCCeREL.emitEnd := dadosComplementares[9];
       EventoCCeREL.emitBairro := dadosComplementares[10];
       EventoCCeREL.emitCEP := dadosComplementares[11];
       EventoCCeREL.emitMun := dadosComplementares[12];
       EventoCCeREL.emitFone := dadosComplementares[13];
       EventoCCeREL.emitUF := dadosComplementares[14];
       EventoCCeREL.emitIE := dadosComplementares[15];

       EventoCCeREL.nnf := dadosComplementares[16];
       EventoCCeREL.serie := dadosComplementares[17];
       if(dadosComplementares.Count > 18) then
         EventoCCeREL.dtEmissaoNFe := dadosComplementares[18];

    end;


    EventoCCeREL.QREventoCCe.PrinterSettings.Copies := nVias;
    EventoCCeREL.QREventoCCe.Prepare;

    if (ConfigImprimir) then
    begin
      EventoCCeREL.QREventoCCe.Print;
    end;

    if (ConfigGerarPDF) then
    begin
       dirPDF := ExtractFilePath(Application.ExeName)+'pdf\';
       nomeArqPDF := dirPDF + StringReplace(filename, '.XML','.PDF', [rfReplaceAll, rfIgnoreCase]);
       GerarPDF(EventoCCeREL.QREventoCCe, nomeArqPDF);
    end;

    enviaEmail := (assigned(EventoCCeREL)) and
                  (assigned(EventoCCeREL.cdsProcCCe)) and
                  (Pos('@', EventoCCeREL.cdsProcCCeemailDest.AsString) > 0);

    //somente será possivel fazer o envio do email se o txt de dados complementares existir              
    if existemDados and enviaEmail and ConfigEnvioAutomatico then
    begin

      TStBody := TStringList.Create;
      TStBody.Add('Esta mensagem refere-se a Nota Fiscal Eletrônica Nacional de Número/Série ' + EventoCCeREL.nnf +'/'+ EventoCCeREL.serie +' emitida para: '+EventoCCeREL.destRazao);
      TStBody.Add('Razão Social: ' + EventoCCeREL.emitRazao );
      TStBody.Add('Chave de acesso: ' + EventoCCeREL.cdsProcCCeinfEvento_chNFe.AsString      );
      TStBody.Add('Protocolo: ' + EventoCCeREL.cdsProcCCenProt.AsString      );
      TStBody.Add('Para verificar a autorização da SEFAZ referente à nota acima mencionada, acesse o site http://www.nfe.fazenda.gov.br/portal     ');
      TStBody.Add('');
      TStBody.Add('Este e-mail foi criado pelo sistema Open NFe');
      TStBody.Add('http://www.rochadigital.com.br                                                                                                 ');
      TStBody.Add('Envio automático. Favor não responder este e-mail.');


      EnviaXMLEmail(EventoCCeREL.QREventoCCe, path, fileName,
                EventoCCeREL.cdsProcCCeemailDest.AsString,
                'CCe '+ EventoCCeREL.cdsProcCCeinfEvento_chNFe.AsString,
                TStBody, false);
    end;

  finally
    EventoCCeREL.Free;
    dadosComplementares.Free;

    if(FileExists(path+txtFileName))then
       DeleteFile(path+txtFileName);
    if not (existemDados and enviaEmail and ConfigEnvioAutomatico) then
    begin
      if(FileExists(path+fileName))then
         DeleteFile(path+fileName);
      Printing := false;
    end;
  end;
end;


procedure TFMain.doPrintNFe(path, fileName : String; nVias : integer);
var
  TStBody : TStringList;
  enviaEmail: Boolean;
  dirPDF, nomeArqPDF : String;
  DANFEREL: TDANFEREL;
begin
  enviaEmail := false;
  DANFEREL := TDANFEREL.Create(Application);
  try
    DANFEREL.XTPNFE.XMLDataFile  := path + fileName;
    DANFEREL.XTPPROT.XMLDataFile  := path + fileName;

    DANFEREL.qrRelatorio.PrinterSettings.Copies := nVias;
    DANFEREL.qrRelatorio.Prepare;
    DANFEREL.TotalDePaginas := DANFEREL.qrRelatorio.QRPrinter.PageCount;

    if (ConfigImprimir) then
    begin
      DANFEREL.qrRelatorio.Print;
    end;

    if (ConfigGerarPDF) then
    begin
       dirPDF := ExtractFilePath(Application.ExeName)+'pdf\';
       nomeArqPDF := dirPDF + StringReplace(filename, '.XML','.PDF', [rfReplaceAll, rfIgnoreCase]);
       GerarPDF(DANFEREL.qrRelatorio, nomeArqPDF);
    end;

    enviaEmail := (assigned(DANFEREL)) and
                  (assigned(DANFEREL.cdsNotaFiscalemail)) and
                  (Pos('@', DANFEREL.cdsNotaFiscalemail.Value) > 0);

    if enviaEmail and ConfigEnvioAutomatico then
    begin
      TStBody := TStringList.Create;
      TStBody.Add('Esta mensagem refere-se a Nota Fiscal Eletrônica Nacional de Número/Série ' + DANFEREL.cdsNotaFiscalnNF.AsString +'/'+ DANFEREL.cdsNotaFiscalserie.AsString+' emitida para: '+DANFEREL.cdsNotaFiscaldest_xNome.AsString);
      TStBody.Add('Razão Social: ' + DANFEREL.cdsNotaFiscalemit_xNome.AsString );
      TStBody.Add('Chave de acesso: ' + DANFEREL.cdsProtNFechNFe.AsString      );
      TStBody.Add('Protocolo: ' + DANFEREL.cdsProtNFenProt.AsString      );
      TStBody.Add('Para verificar a autorização da SEFAZ referente à nota acima mencionada, acesse o site http://www.nfe.fazenda.gov.br/portal     ');
      TStBody.Add('');
      TStBody.Add('Este e-mail foi criado pelo sistema Open NFe');
      TStBody.Add('http://www.rochadigital.com.br                                                                                                 ');
      TStBody.Add('Envio automático. Favor não responder este e-mail.');


      EnviaXMLEmail(DANFEREL.qrRelatorio, path, fileName,
                DANFEREL.cdsNotaFiscalemail.AsString,
                'NFe '+ DANFEREL.cdsProtNFechNFe.AsString,
                TStBody, false);
    end;

  finally
    DANFEREL.Free;
    if not (enviaEmail and ConfigEnvioAutomatico) then
    begin
      if(FileExists(path+fileName))then
         DeleteFile(path+fileName);
      Printing := false;
    end;
  end;
end;


procedure TFMain.doPrintCancNFe(path, fileName : String; nVias : integer);
var
  enviaEmail: Boolean;
  txtFileName : String;
  dest, TStBody: TStringList;
begin
  dest := TStringList.Create;
  enviaEmail := false;
  try
    txtFileName := StringReplace(fileName, '.xml','.txt',[rfReplaceAll,rfIgnoreCase]);

    //se existir o arquivo .txt
    enviaEmail :=  FileExists(path+txtFileName );

    if enviaEmail and ConfigEnvioAutomatico then
    begin

      dest.LoadFromFile(path+txtFileName);

      TStBody := TStringList.Create;
      TStBody.Add('Esta mensagem refere-se a Nota Fiscal Eletrônica Nacional de Número/Série ' + dest[2]+'/'+dest[3] +' emitida para:  '+dest[6]);
      TStBody.Add('Razão Social: ' + dest[4] );
      TStBody.Add('Chave de acesso: ' + dest[1]     );
      TStBody.Add('Protocolo de Cancelamento: ' + dest[5]      );
      TStBody.Add('Para verificar a autorização da SEFAZ referente à nota acima mencionada, acesse o site http://www.nfe.fazenda.gov.br/portal     ');
      TStBody.Add('');
      TStBody.Add('Este e-mail foi criado pelo sistema Open NFe');
      TStBody.Add('http://www.rochadigital.com.br                                                                                                 ');
      TStBody.Add('Envio automático. Favor não responder este e-mail.');

      EnviaXMLEmail(nil, path, fileName, dest[0],'Cancelamento NFe ' + dest[1], TStBody, false);
    end;

  finally
    dest.Free;

    if(FileExists(path+txtFileName))then
       DeleteFile(path+txtFileName);
    if not (enviaEmail and ConfigEnvioAutomatico) then
    begin
      if(FileExists(path+fileName))then
         DeleteFile(path+fileName);
      Printing := false;
    end;
  end;
end;


procedure TFMain.EnviaXMLEmail(report : TQuickRep; path, fileName, dest, subject : String; body : TStringList; teste : Boolean);
var
  smtp: TIdSMTP;
  dirTemp, nomeArqPDF: String;
begin

  if teste then
    smtp := smtpEnviaMailTeste
  else
    smtp := smtpEnviaXML;

  smtp.Username := ConfigUsuario;
  smtp.Host := ConfigHost;
  smtp.Password := ConfigSenha;
  smtp.Port := StrToInt(ConfigPort);

  if(ConfigSSL) then
  begin
    smtp.IOHandler := sslSocket;
    smtp.AuthenticationType := atLogin;
  end;

  try

    if not smtp.Connected then
    smtp.Connect();

    if smtp.AuthSchemesSupported.IndexOf('LOGIN')>-1 then
    begin
      smtp.AuthenticationType := atLogin;
    end;

    smtp.Authenticate;

    if (not teste) and (dest <> '') then
    begin
      msgEmail.Recipients.EMailAddresses := dest;
    end
    else
    begin
      msgEmail.Recipients.EMailAddresses := ConfigFrom;
    end;

    msgEmail.CCList.EMailAddresses := ConfigCopiaPara;

    msgEmail.From.Text := ConfigTextoFrom;
    msgEmail.From.Address := ConfigFrom;
    if teste then
      msgEmail.Subject := 'Teste de envio de e-mail do Open NFe'
    else
      msgEmail.Subject := subject;

    msgEmail.Body.Clear;

    if teste then
      msgEmail.Body.Add('Envio de e-mail de teste do Open NFe. Favor não responder.')
    else
      msgEmail.Body.AddStrings(body);

    msgEmail.MessageParts.Clear;

    if Trim(filename) <> '' then
    begin
      TIdAttachment.Create(msgEmail.MessageParts , Tfilename(path + filename));

      if((report <> nil) and ConfigEnviarPDF) then
      begin
          dirTemp := ExtractFilePath(Application.ExeName)+'temp\';
          nomeArqPDF := dirTemp + StringReplace(filename, '.XML','.PDF', [rfReplaceAll, rfIgnoreCase]);

          GerarPDF(report, nomeArqPDF);

          TIdAttachment.Create(msgEmail.MessageParts , Tfilename(NomeArqPDF));
      end;


    end;


    if teste or (dest <> '') then
    begin
        smtp.Send(msgEmail);
    end;

  finally
    if smtp.Connected then
      smtp.Disconnect;
  end;

end;

procedure TFMain.GerarPDF(report:TQuickRep; nomeArqPDF :string);
var
 dir : String;
begin
   dir := ExtractFilePath(nomeArqPDF);
   if(not DirectoryExists(dir)) then
    CreateDir(dir);

   if(FileExists(nomeArqPDF)) then
     DeleteFile(nomeArqPDF);


   pdfEngine.FileName := nomeArqPDF;
   pdfEngine.Preferences.OpenAfterCreate := false;
   pdfExport.RenderDocument(report, true);
end;

procedure TFMain.Button1Click(Sender: TObject);
begin
  ClosedByButton := true;
  Close;
end;

function TFMain.GetUtils: NFEUtils;
begin
  if (not assigned(_Utils)) then
    _Utils := NFEUtils.Create();
  result := _Utils;
end;

procedure TFMain.Button2Click(Sender: TObject);
begin
   TConfig.ShowModal;
end;

procedure TFMain.ApplicationEvents1Exception(Sender: TObject;  E: Exception);
var
    NomeDoLog: string;
    Arquivo: TextFile;
  begin
    NomeDoLog := ChangeFileExt(Application.Exename, '.erro.log');
    AssignFile(Arquivo, NomeDoLog);

    if FileExists(NomeDoLog) then
      Append(arquivo) { se existir, apenas adiciona linhas }
    else
      ReWrite(arquivo); { cria um novo se não existir }

    try
      WriteLn(arquivo, DateTimeToStr(Now) + ': ' + E.Message);
      WriteLn(arquivo,'----------------------------------------------------------------------');
    finally
      CloseFile(arquivo);

      if Printing then
      begin

        if lvArquivos.Count > 0 then
        begin
          DeleteFile(ExtractFilePath(Application.ExeName)+'PrintBox\'+ lvArquivos.Items[0]);
          if FileExists(ExtractFilePath(Application.ExeName)+'PrintBox\'+ StringReplace(lvArquivos.Items[0],'.xml','.txt',[rfReplaceAll,rfIgnoreCase])) then
            DeleteFile(ExtractFilePath(Application.ExeName)+'PrintBox\'+ StringReplace(lvArquivos.Items[0],'.xml','.txt',[rfReplaceAll,rfIgnoreCase]));
        end;

        Printing := false;

      end;

    end;

end;

procedure TFMain.smtpEnviaXMLWorkEnd(Sender: TObject;
  AWorkMode: TWorkMode);
var
  dir, dirTemp,   nomeArquivoXML, nomeArquivoTXT, nomeArquivoPDF: String;
begin
  dir := ExtractFilePath(Application.ExeName)+'PrintBox\';
  dirTemp := ExtractFilePath(Application.ExeName)+'temp\';

  nomeArquivoXML := lvArquivos.Items[0];
  nomeArquivoTXT := StringReplace(nomeArquivoXML,'.xml','.txt',[rfReplaceAll,rfIgnoreCase]);
  nomeArquivoPDF := StringReplace(nomeArquivoXML,'.xml','.pdf',[rfReplaceAll,rfIgnoreCase]);

  //apagar xml após envio
  if FileExists(dir+ nomeArquivoXML) then
     DeleteFile(dir+ nomeArquivoXML);

  //apagar txt após envio
  if FileExists(dir+ nomeArquivoTXT) then
     DeleteFile(dir+ nomeArquivoTXT);

  //apagar pdf temp após envio
  if FileExists(dirTemp+ nomeArquivoPDF) then
     DeleteFile(dirTemp+ nomeArquivoPDF);

  Printing := false;
end;

procedure TFMain.Cd1Click(Sender: TObject);
begin
  TConfig.ShowModal;
end;

procedure TFMain.Encerrar1Click(Sender: TObject);
begin
ClosedByButton := true;
  Close;
end;

end.
