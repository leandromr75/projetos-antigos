unit relatorioEventoCCe;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, QuickRpt, xmldom, DB, DBClient, Provider, Xmlxform,
  QRCtrls, StdCtrls, Mask, DBCtrls, Barcode;

type
  TEventoCCeREL = class(TForm)
    QREventoCCe: TQuickRep;
    XTRProcCCe: TXMLTransformProvider;
    dsProcCCe: TDataSource;
    detailBand: TQRBand;
    qtEnderEmit_xLgr: TQRDBText;
    qtSysCliRazSoc: TQRDBText;
    qtSysCliEndBai: TQRDBText;
    qtenderEmit_CEP: TQRDBText;
    qtSysCliTel: TQRDBText;
    qtSysCidNom: TQRDBText;
    QRShape2: TQRShape;
    qiLogomarca: TQRImage;
    qiCodigoBarras: TQRImage;
    QRLabel1: TQRLabel;
    QRLabel106: TQRLabel;
    qtChaveAcesso: TQRDBText;
    QRLabel2: TQRLabel;
    QRLabel3: TQRLabel;
    QRShape4: TQRShape;
    QRShape1: TQRShape;
    QRShape5: TQRShape;
    cdsProcCCe: TClientDataSet;
    QRLabel22: TQRLabel;
    QRLabel23: TQRLabel;
    qtdest_xNome: TQRDBText;
    QRLabel26: TQRLabel;
    QRDBText2: TQRDBText;
    QRLabel30: TQRLabel;
    QRDBText4: TQRDBText;
    QRShape17: TQRShape;
    QRLabel31: TQRLabel;
    qtFoneFax: TQRDBText;
    QRShape13: TQRShape;
    QRShape18: TQRShape;
    QRLabel32: TQRLabel;
    qtenderDestUF: TQRDBText;
    QRShape19: TQRShape;
    QRLabel33: TQRLabel;
    qtDestIE: TQRDBText;
    QRLabel28: TQRLabel;
    qtenderDest_CEP: TQRDBText;
    QRShape14: TQRShape;
    qtenderDest_xBairro: TQRDBText;
    QRLabel24: TQRLabel;
    qtdest_CNPJ: TQRDBText;
    QRShape10: TQRShape;
    QRShape3: TQRShape;
    QRShape8: TQRShape;
    QRShape12: TQRShape;
    QRLabel105: TQRLabel;
    QRDBText1: TQRDBText;
    QRDBText3: TQRDBText;
    QRShape6: TQRShape;
    QRLabel4: TQRLabel;
    QRShape7: TQRShape;
    QRLabel5: TQRLabel;
    QRLabel6: TQRLabel;
    QRShape9: TQRShape;
    QRShape11: TQRShape;
    QRShape15: TQRShape;
    QRLabel9: TQRLabel;
    QRDBText7: TQRDBText;
    QRLabel7: TQRLabel;
    QRLabel8: TQRLabel;
    QRLabel10: TQRLabel;
    QRShape16: TQRShape;
    QRDBText5: TQRDBText;
    QRDBText6: TQRDBText;
    cdsProcCCeversao1: TStringField;
    cdsProcCCeevento_versao: TStringField;
    cdsProcCCeinfEvento_Id: TStringField;
    cdsProcCCeinfEvento_cOrgao: TStringField;
    cdsProcCCeinfEvento_tpAmb: TStringField;
    cdsProcCCeCNPJ: TStringField;
    cdsProcCCeCPF: TStringField;
    cdsProcCCeinfEvento_chNFe: TStringField;
    cdsProcCCedhEvento: TStringField;
    cdsProcCCeinfEvento_tpEvento: TStringField;
    cdsProcCCeinfEvento_nSeqEvento: TStringField;
    cdsProcCCeverEvento: TStringField;
    cdsProcCCeversao2: TStringField;
    cdsProcCCedescEvento: TStringField;
    cdsProcCCexCorrecao: TStringField;
    cdsProcCCexCondUso: TStringField;
    cdsProcCCeretEvento_versao: TStringField;
    cdsProcCCeinfRetEvento_Id: TStringField;
    cdsProcCCeinfRetEvento_tpAmb: TStringField;
    cdsProcCCeverAplic: TStringField;
    cdsProcCCeinfRetEvento_cOrgao: TStringField;
    cdsProcCCecStat: TStringField;
    cdsProcCCexMotivo: TStringField;
    cdsProcCCeinfRetEvento_chNFe: TStringField;
    cdsProcCCeinfRetEvento_tpEvento: TStringField;
    cdsProcCCexEvento: TStringField;
    cdsProcCCeinfRetEvento_nSeqEvento: TStringField;
    cdsProcCCeCNPJDest: TStringField;
    cdsProcCCeCPFDest: TStringField;
    cdsProcCCeemailDest: TStringField;
    cdsProcCCedhRegEvento: TStringField;
    cdsProcCCenProt: TStringField;
    QRLabel11: TQRLabel;
    QRLabel12: TQRLabel;
    QRDBText8: TQRDBText;
    QRShape20: TQRShape;
    QRDBText9: TQRDBText;
    QRDBText10: TQRDBText;
    QRShape21: TQRShape;
    QRLabel13: TQRLabel;
    QRShape22: TQRShape;
    QRShape23: TQRShape;
    QRDBText11: TQRDBText;
    QRLabel14: TQRLabel;
    QRLabel15: TQRLabel;
    QRDBText12: TQRDBText;
    QRShape24: TQRShape;
    QRDBText13: TQRDBText;
    QRLabel16: TQRLabel;
    QRShape25: TQRShape;
    QRLabel17: TQRLabel;
    QRDBText14: TQRDBText;
    QRShape26: TQRShape;
    QRLabel18: TQRLabel;
    QRDBText15: TQRDBText;
    QRDBText16: TQRDBText;
    QRShape27: TQRShape;
    QRShape28: TQRShape;
    QRShape29: TQRShape;
    QRShape30: TQRShape;
    QRLabel19: TQRLabel;
    QRLabel20: TQRLabel;
    QRDBText19: TQRDBText;
    QRDBText20: TQRDBText;
    procedure FormCreate(Sender: TObject);
    procedure QREventoCCeBeforePrint(Sender: TCustomQuickRep;
      var PrintReport: Boolean);
    procedure qtSysCliRazSocPrint(sender: TObject; var Value: String);
    procedure qtEnderEmit_xLgrPrint(sender: TObject; var Value: String);
    procedure qtSysCliEndBaiPrint(sender: TObject; var Value: String);
    procedure qtenderEmit_CEPPrint(sender: TObject; var Value: String);
    procedure qtSysCidNomPrint(sender: TObject; var Value: String);
    procedure qtSysCliTelPrint(sender: TObject; var Value: String);
    procedure qtdest_xNomePrint(sender: TObject; var Value: String);
    procedure qtdest_CNPJPrint(sender: TObject; var Value: String);
    procedure QRDBText2Print(sender: TObject; var Value: String);
    procedure qtenderDest_xBairroPrint(sender: TObject; var Value: String);
    procedure qtenderDest_CEPPrint(sender: TObject; var Value: String);
    procedure QRDBText4Print(sender: TObject; var Value: String);
    procedure qtFoneFaxPrint(sender: TObject; var Value: String);
    procedure qtenderDestUFPrint(sender: TObject; var Value: String);
    procedure qtDestIEPrint(sender: TObject; var Value: String);
    procedure QRDBText10Print(sender: TObject; var Value: String);
    procedure QRDBText9Print(sender: TObject; var Value: String);
    procedure QRDBText17Print(sender: TObject; var Value: String);
    procedure QRDBText16Print(sender: TObject; var Value: String);
    procedure QRDBText19Print(sender: TObject; var Value: String);
    procedure QRDBText20Print(sender: TObject; var Value: String);
  private
    { Private declarations }
    Barcode1 : TAsBarcode;
  public
    { Public declarations }
    destRazao, destEnd, destBairro, destCEP, destMun, destFone, destUF, destIE : String;
    emitRazao, emitEnd, emitBairro, emitCEP, emitMun, emitFone, emitUF, emitIE : String;
    nnf, serie, dtEmissaoNFe : String;

  end;

//var
//  EventoCCeREL: TEventoCCeREL;

implementation

{$R *.dfm}

procedure TEventoCCeREL.FormCreate(Sender: TObject);
begin
  Barcode1 := TAsBarcode.Create(self);
  Barcode1.Height := qiCodigoBarras.Height;
  Barcode1.Width := qiCodigoBarras.Width;
  Barcode1.Typ := bcCode128C;
  Barcode1.Modul := 1;
  Barcode1.Ratio := 2.0;
end;

procedure TEventoCCeREL.QREventoCCeBeforePrint(Sender: TCustomQuickRep;
  var PrintReport: Boolean);
var
  ArqNom : string;
  ratio : Extended;
begin
  {Fecha os datasets.}
  cdsProcCCe.Close;

  {Carrega o schema xtr.}
  ArqNom := ExtractFilePath(Application.ExeName) + 'xsd\ToDpProcCCe.xtr';
  XTRProcCCe.TransformRead.TransformationFile  := ArqNom;
  XTRProcCCe.TransformWrite.TransformationFile := ArqNom;

  {Carrega a logomarca.}
  if FileExists(ExtractFilePath(Application.ExeName) + 'Logomarca.bmp') then
  begin
    ArqNom := ExtractFilePath(Application.ExeName) + 'Logomarca.bmp';
    qiLogomarca.Picture.LoadFromFile(ArqNom);
    ratio := qiLogomarca.Picture.Bitmap.Height / qiLogomarca.Picture.Bitmap.Width;
    qiLogomarca.Picture.Bitmap.Height := Round(qiLogomarca.Width / ratio);
  end;

  {Carrega os dados do xml.}
  cdsProcCCe.Open;

  {carrega a chave da nota no titulo do relatorio}
  QREventoCCe.ReportTitle := cdsProcCCeinfEvento_chNFe.AsString;

  {codigo de barras}
  Barcode1.Text := copy(cdsProcCCeinfEvento_chNFe.AsString, 4, 44);
 	Barcode1.DrawBarcode(qiCodigoBarras.Canvas);
end;

procedure TEventoCCeREL.qtSysCliRazSocPrint(sender: TObject;
  var Value: String);
begin
  Value := emitRazao;
end;

procedure TEventoCCeREL.qtEnderEmit_xLgrPrint(sender: TObject;
  var Value: String);
begin
  Value := 'End. : ' + emitEnd;
end;

procedure TEventoCCeREL.qtSysCliEndBaiPrint(sender: TObject;
  var Value: String);
begin
  Value := 'Bairro : ' + emitBairro;
end;

procedure TEventoCCeREL.qtenderEmit_CEPPrint(sender: TObject;
  var Value: String);
begin
  Value := 'CEP : ' + emitCEP;
end;

procedure TEventoCCeREL.qtSysCidNomPrint(sender: TObject;
  var Value: String);
begin
  Value := 'Mun. : ' + emitMun;
end;

procedure TEventoCCeREL.qtSysCliTelPrint(sender: TObject;
  var Value: String);
begin
  Value := 'Tel. : '+ emitFone;
end;

procedure TEventoCCeREL.qtdest_xNomePrint(sender: TObject;
  var Value: String);
begin
  Value := destRazao;
end;

procedure TEventoCCeREL.qtdest_CNPJPrint(sender: TObject;
  var Value: String);
begin
  if(cdsProcCCeCNPJDest.AsString <> '') then
    Value := cdsProcCCeCNPJDest.AsString
  else if (cdsProcCCeCPFDest.AsString <> '') then
       Value := cdsProcCCeCPFDest.AsString
  else
      Value := 'Não informado';


end;

procedure TEventoCCeREL.QRDBText2Print(sender: TObject; var Value: String);
begin
  Value := destEnd;
end;

procedure TEventoCCeREL.qtenderDest_xBairroPrint(sender: TObject;
  var Value: String);
begin
  Value := destBairro;
end;

procedure TEventoCCeREL.qtenderDest_CEPPrint(sender: TObject;
  var Value: String);
begin
  Value :=  destCEP;
end;

procedure TEventoCCeREL.QRDBText4Print(sender: TObject; var Value: String);
begin
  Value := destMun;
end;

procedure TEventoCCeREL.qtFoneFaxPrint(sender: TObject; var Value: String);
begin
  Value := destFone;
end;

procedure TEventoCCeREL.qtenderDestUFPrint(sender: TObject;
  var Value: String);
begin
  Value := destUF;
end;

procedure TEventoCCeREL.qtDestIEPrint(sender: TObject; var Value: String);
begin
  Value := destIE;
end;

procedure TEventoCCeREL.QRDBText10Print(sender: TObject;
  var Value: String);
  var origem : String;
begin
    //converter data para 12/03/2009 10:00:00
  origem := Value;
  Value := copy(origem, 9 , 2); //dia
  Value := Value + '/' + copy(origem, 6 , 2); //mes
  Value := Value + '/' + copy(origem, 0 , 4); //ano
  Value := Value + ' ' + copy(origem, 12 , 8); //horas
end;

procedure TEventoCCeREL.QRDBText9Print(sender: TObject; var Value: String);
  var origem : String;
begin
    //converter data para 12/03/2009 10:00:00
  origem := Value;
  Value := copy(origem, 9 , 2); //dia
  Value := Value + '/' + copy(origem, 6 , 2); //mes
  Value := Value + '/' + copy(origem, 0 , 4); //ano
  Value := Value + ' ' + copy(origem, 12 , 8); //horas
end;

procedure TEventoCCeREL.QRDBText17Print(sender: TObject;
  var Value: String);
begin
 Value := 'CC da Nota Nº: ' + nnf
        + ' - Série : ' + serie ;
end;

procedure TEventoCCeREL.QRDBText16Print(sender: TObject;
  var Value: String);
begin
 Value := 'CNPJ : ' + Value;
end;

procedure TEventoCCeREL.QRDBText19Print(sender: TObject;
  var Value: String);
  var origem : String;
begin
        //converter data para 12/03/2009 10:00:00
  origem := dtEmissaoNFe;
  Value := copy(origem, 9 , 2); //dia
  Value := Value + '/' + copy(origem, 6 , 2); //mes
  Value := Value + '/' + copy(origem, 0 , 4); //ano
//  Value := Value + ' ' + copy(origem, 12 , 8); //horas
end;

procedure TEventoCCeREL.QRDBText20Print(sender: TObject;
  var Value: String);
begin
           Value := nnf  + ' / ' + serie ;
end;

end.
