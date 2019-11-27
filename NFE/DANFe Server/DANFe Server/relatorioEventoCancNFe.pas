unit relatorioEventoCancNFe;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, QuickRpt, xmldom, DB, DBClient, Provider, Xmlxform,
  QRCtrls, StdCtrls, Mask, DBCtrls, Barcode;

type
  TEventoCancNFeREL = class(TForm)
    QREventoCancNFe: TQuickRep;
    XTRProcCancNFe: TXMLTransformProvider;
    dsProcCancNFe: TDataSource;
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
    QRLabel3: TQRLabel;
    QRShape1: TQRShape;
    QRShape5: TQRShape;
    cdsProcCancNFe: TClientDataSet;
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
    cdsProcCancNFeversao1: TStringField;
    cdsProcCancNFeevento_versao: TStringField;
    cdsProcCancNFeinfEvento_Id: TStringField;
    cdsProcCancNFeinfEvento_cOrgao: TStringField;
    cdsProcCancNFeinfEvento_tpAmb: TStringField;
    cdsProcCancNFeCNPJ: TStringField;
    cdsProcCancNFeCPF: TStringField;
    cdsProcCancNFeinfEvento_chNFe: TStringField;
    cdsProcCancNFedhEvento: TStringField;
    cdsProcCancNFeinfEvento_tpEvento: TStringField;
    cdsProcCancNFeinfEvento_nSeqEvento: TStringField;
    cdsProcCancNFeverEvento: TStringField;
    cdsProcCancNFeversao2: TStringField;
    cdsProcCancNFedescEvento: TStringField;
    cdsProcCancNFenProtAutorizacao: TStringField;
    cdsProcCancNFexJust: TStringField;
    cdsProcCancNFeretEvento_versao: TStringField;
    cdsProcCancNFeinfRetEvento_Id: TStringField;
    cdsProcCancNFeinfRetEvento_tpAmb: TStringField;
    cdsProcCancNFeverAplic: TStringField;
    cdsProcCancNFeinfRetEvento_cOrgao: TStringField;
    cdsProcCancNFecStat: TStringField;
    cdsProcCancNFexMotivo: TStringField;
    cdsProcCancNFeinfRetEvento_chNFe: TStringField;
    cdsProcCancNFeinfRetEvento_tpEvento: TStringField;
    cdsProcCancNFexEvento: TStringField;
    cdsProcCancNFeinfRetEvento_nSeqEvento: TStringField;
    cdsProcCancNFeCNPJDest: TStringField;
    cdsProcCancNFeCPFDest: TStringField;
    cdsProcCancNFeemailDest: TStringField;
    cdsProcCancNFedhRegEvento: TStringField;
    cdsProcCancNFenProt: TStringField;
    QRShape4: TQRShape;
    QRLabel2: TQRLabel;
    QRDBText3: TQRDBText;
    QRShape27: TQRShape;
    QRShape28: TQRShape;
    procedure FormCreate(Sender: TObject);
    procedure QREventoCancNFeBeforePrint(Sender: TCustomQuickRep;
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
  private
    { Private declarations }
    Barcode1 : TAsBarcode;
  public
    { Public declarations }
    destRazao, destEnd, destBairro, destCEP, destMun, destFone, destUF, destIE : String;
    emitRazao, emitEnd, emitBairro, emitCEP, emitMun, emitFone, emitUF, emitIE : String;
    nnf, serie : String; 

  end;

//var
//  EventoCancNFeREL: TEventoCancNFeREL;

implementation

{$R *.dfm}

procedure TEventoCancNFeREL.FormCreate(Sender: TObject);
begin
  Barcode1 := TAsBarcode.Create(self);
  Barcode1.Height := qiCodigoBarras.Height;
  Barcode1.Width := qiCodigoBarras.Width;
  Barcode1.Typ := bcCode128C;
  Barcode1.Modul := 1;
  Barcode1.Ratio := 2.0;
end;

procedure TEventoCancNFeREL.QREventoCancNFeBeforePrint(Sender: TCustomQuickRep;
  var PrintReport: Boolean);
var
  ArqNom : string;
  ratio : Extended;
begin
  {Fecha os datasets.}
  cdsProcCancNFe.Close;

  {Carrega o schema xtr.}
  ArqNom := ExtractFilePath(Application.ExeName) + 'xsd\ToDpProcCCe_CancNFe.xtr';
  XTRProcCancNFe.TransformRead.TransformationFile  := ArqNom;
  XTRProcCancNFe.TransformWrite.TransformationFile := ArqNom;

  {Carrega a logomarca.}
  if FileExists(ExtractFilePath(Application.ExeName) + 'Logomarca.bmp') then
  begin
    ArqNom := ExtractFilePath(Application.ExeName) + 'Logomarca.bmp';
    qiLogomarca.Picture.LoadFromFile(ArqNom);
    ratio := qiLogomarca.Picture.Bitmap.Height / qiLogomarca.Picture.Bitmap.Width;
    qiLogomarca.Picture.Bitmap.Height := Round(qiLogomarca.Width / ratio);
  end;

  {Carrega os dados do xml.}
  cdsProcCancNFe.Open;

  {carrega a chave da nota no titulo do relatorio}
  QREventoCancNFe.ReportTitle := cdsProcCancNFeinfEvento_chNFe.AsString;

  {codigo de barras}
  Barcode1.Text := copy(cdsProcCancNFeinfEvento_chNFe.AsString, 4, 44);
 	Barcode1.DrawBarcode(qiCodigoBarras.Canvas);
end;

procedure TEventoCancNFeREL.qtSysCliRazSocPrint(sender: TObject;
  var Value: String);
begin
  Value := emitRazao;
end;

procedure TEventoCancNFeREL.qtEnderEmit_xLgrPrint(sender: TObject;
  var Value: String);
begin
  Value := emitEnd;
end;

procedure TEventoCancNFeREL.qtSysCliEndBaiPrint(sender: TObject;
  var Value: String);
begin
  Value := emitBairro;   
end;

procedure TEventoCancNFeREL.qtenderEmit_CEPPrint(sender: TObject;
  var Value: String);
begin
  Value := emitCEP;
end;

procedure TEventoCancNFeREL.qtSysCidNomPrint(sender: TObject;
  var Value: String);
begin
  Value := emitMun;
end;

procedure TEventoCancNFeREL.qtSysCliTelPrint(sender: TObject;
  var Value: String);
begin
  Value := emitFone;
end;

procedure TEventoCancNFeREL.qtdest_xNomePrint(sender: TObject;
  var Value: String);
begin
  Value := destRazao;
end;

procedure TEventoCancNFeREL.qtdest_CNPJPrint(sender: TObject;
  var Value: String);
begin
  if(cdsProcCancNFeCNPJDest.AsString <> '') then
    Value := cdsProcCancNFeCNPJDest.AsString
  else if (cdsProcCancNFeCPFDest.AsString <> '') then
       Value := cdsProcCancNFeCPFDest.AsString
  else
      Value := 'Não informado';


end;

procedure TEventoCancNFeREL.QRDBText2Print(sender: TObject; var Value: String);
begin
  Value := destEnd;
end;

procedure TEventoCancNFeREL.qtenderDest_xBairroPrint(sender: TObject;
  var Value: String);
begin
  Value := destBairro;
end;

procedure TEventoCancNFeREL.qtenderDest_CEPPrint(sender: TObject;
  var Value: String);
begin
  Value :=  destCEP;
end;

procedure TEventoCancNFeREL.QRDBText4Print(sender: TObject; var Value: String);
begin
  Value := destMun;
end;

procedure TEventoCancNFeREL.qtFoneFaxPrint(sender: TObject; var Value: String);
begin
  Value := destFone;
end;

procedure TEventoCancNFeREL.qtenderDestUFPrint(sender: TObject;
  var Value: String);
begin
  Value := destUF;
end;

procedure TEventoCancNFeREL.qtDestIEPrint(sender: TObject; var Value: String);
begin
  Value := destIE;
end;

procedure TEventoCancNFeREL.QRDBText10Print(sender: TObject;
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

procedure TEventoCancNFeREL.QRDBText9Print(sender: TObject; var Value: String);
  var origem : String;
begin
    //converter data para 12/03/2009 10:00:00
  origem := Value;
  Value := copy(origem, 9 , 2); //dia
  Value := Value + '/' + copy(origem, 6 , 2); //mes
  Value := Value + '/' + copy(origem, 0 , 4); //ano
  Value := Value + ' ' + copy(origem, 12 , 8); //horas
end;

end.
