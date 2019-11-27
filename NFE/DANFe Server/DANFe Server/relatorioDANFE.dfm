object DANFEREL: TDANFEREL
  Left = 23
  Top = 56
  Width = 812
  Height = 589
  VertScrollBar.Position = 636
  Caption = 'DANFE - Nota Fiscal Eletr'#244'nica'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Arial'
  Font.Style = []
  OldCreateOrder = False
  Scaled = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 14
  object qrRelatorio: TQuickRep
    Tag = 1
    Left = 0
    Top = -628
    Width = 1111
    Height = 1572
    Frame.Color = clBlack
    Frame.DrawTop = True
    Frame.DrawBottom = True
    Frame.DrawLeft = True
    Frame.DrawRight = True
    BeforePrint = qrRelatorioBeforePrint
    DataSet = cdsItensDaNota
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Arial'
    Font.Pitch = fpFixed
    Font.Style = []
    Functions.Strings = (
      'PAGENUMBER'
      'COLUMNNUMBER'
      'REPORTTITLE')
    Functions.DATA = (
      '0'
      '0'
      #39#39)
    Options = [FirstPageHeader, LastPageFooter]
    Page.Columns = 1
    Page.Orientation = poPortrait
    Page.PaperSize = A4
    Page.Continuous = False
    Page.Values = (
      50.000000000000000000
      2970.000000000000000000
      50.000000000000000000
      2100.000000000000000000
      100.000000000000000000
      100.000000000000000000
      0.000000000000000000)
    PrinterSettings.Copies = 1
    PrinterSettings.OutputBin = Auto
    PrinterSettings.Duplex = False
    PrinterSettings.FirstPage = 0
    PrinterSettings.LastPage = 0
    PrinterSettings.UseStandardprinter = False
    PrinterSettings.UseCustomBinCode = False
    PrinterSettings.CustomBinCode = 0
    PrinterSettings.ExtendedDuplex = 0
    PrinterSettings.UseCustomPaperCode = False
    PrinterSettings.CustomPaperCode = 0
    PrinterSettings.PrintMetaFile = False
    PrinterSettings.PrintQuality = 0
    PrinterSettings.Collate = 0
    PrinterSettings.ColorOption = 0
    PrintIfEmpty = False
    ReportTitle = 'Nota Fiscal'
    SnapToGrid = True
    Units = MM
    Zoom = 140
    PrevFormStyle = fsNormal
    PreviewInitialState = wsNormal
    PrevInitialZoom = qrZoomToFit
    PreviewDefaultSaveType = stQRP
    object qbDestinatario: TQRGroup
      Left = 53
      Top = 373
      Width = 1005
      Height = 513
      Frame.Color = clBlack
      Frame.DrawTop = False
      Frame.DrawBottom = False
      Frame.DrawLeft = False
      Frame.DrawRight = False
      AlignToBottom = False
      Color = clWhite
      TransparentBand = False
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -9
      Font.Name = 'Arial'
      Font.Pitch = fpFixed
      Font.Style = []
      ForceNewColumn = False
      ForceNewPage = False
      ParentFont = False
      Size.Values = (
        969.508928571428600000
        1899.330357142857000000)
      PreCaluculateBandHeight = False
      KeepOnOnePage = False
      Master = qrRelatorio
      ReprintOnNewPage = False
      object QRShape16: TQRShape
        Left = 0
        Top = 94
        Width = 1005
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095240000
          0.000000000000000000
          177.648809523809500000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape21: TQRShape
        Left = 0
        Top = 152
        Width = 1005
        Height = 76
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          143.630952380952400000
          0.000000000000000000
          287.261904761904800000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape22: TQRShape
        Left = 0
        Top = 248
        Width = 1005
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095240000
          0.000000000000000000
          468.690476190476300000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape40: TQRShape
        Left = 0
        Top = 383
        Width = 1005
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          0.000000000000000000
          723.824404761904800000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape33: TQRShape
        Left = 0
        Top = 342
        Width = 1005
        Height = 41
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          77.485119047619050000
          0.000000000000000000
          646.339285714285700000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape52: TQRShape
        Left = 0
        Top = 478
        Width = 1005
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Frame.Width = 0
        Size.Values = (
          64.255952380952380000
          0.000000000000000000
          903.363095238095400000
          1899.330357142857000000)
        Pen.Mode = pmBlack
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape44: TQRShape
        Left = 0
        Top = 421
        Width = 1005
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          0.000000000000000000
          795.639880952381100000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape55: TQRShape
        Left = 426
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          805.089285714285800000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape56: TQRShape
        Left = 461
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          871.235119047619200000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape57: TQRShape
        Left = 501
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          946.830357142857100000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape58: TQRShape
        Left = 540
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1020.535714285714000000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape59: TQRShape
        Left = 603
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1139.598214285714000000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape60: TQRShape
        Left = 672
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1270.000000000000000000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape61: TQRShape
        Left = 745
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1407.961309523810000000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape62: TQRShape
        Left = 807
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1525.133928571429000000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape63: TQRShape
        Left = 866
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1636.636904761905000000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape64: TQRShape
        Left = 930
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1757.589285714286000000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape65: TQRShape
        Left = 966
        Top = 478
        Width = 4
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1825.625000000000000000
          903.363095238095400000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape43: TQRShape
        Left = 793
        Top = 420
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1498.675595238095000000
          793.750000000000000000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape39: TQRShape
        Left = 793
        Top = 382
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1498.675595238095000000
          721.934523809523800000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape49: TQRShape
        Left = 793
        Top = 342
        Width = 3
        Height = 41
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          77.485119047619050000
          1498.675595238095000000
          646.339285714285700000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape51: TQRShape
        Left = 792
        Top = 152
        Width = 3
        Height = 76
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          143.630952380952400000
          1496.785714285714000000
          287.261904761904800000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape50: TQRShape
        Left = 579
        Top = 152
        Width = 3
        Height = 76
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          143.630952380952400000
          1094.241071428571000000
          287.261904761904800000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape3: TQRShape
        Left = 0
        Top = 60
        Width = 1005
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          0.000000000000000000
          113.392857142857100000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape13: TQRShape
        Left = 437
        Top = 59
        Width = 3
        Height = 35
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          66.145833333333340000
          825.877976190476200000
          111.502976190476200000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape9: TQRShape
        Left = 0
        Top = 22
        Width = 1005
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          0.000000000000000000
          41.577380952380950000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRLabel22: TQRLabel
        Left = 4
        Top = 4
        Width = 276
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          7.559523809523811000
          7.559523809523811000
          521.607142857142900000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DESTINAT'#193'RIO REMETENTE'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel23: TQRLabel
        Left = 4
        Top = 26
        Width = 141
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          7.559523809523811000
          49.136904761904770000
          266.473214285714300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'NOME/RAZ'#195'O SOCIAL'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtdest_xNome: TQRDBText
        Left = 12
        Top = 38
        Width = 529
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          33.072916666666670000
          23.151041666666670000
          71.106770833333340000
          1000.455729166667000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'dest_xNome'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape10: TQRShape
        Left = 549
        Top = 22
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1037.544642857143000000
          41.577380952380950000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel24: TQRLabel
        Left = 556
        Top = 26
        Width = 64
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1050.773809523810000000
          49.136904761904770000
          120.952380952381000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CNPJ/CPF'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtdest_CNPJ: TQRDBText
        Left = 564
        Top = 38
        Width = 220
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1065.892857142857000000
          71.815476190476190000
          415.773809523809600000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'dest_CNPJ'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtdest_CNPJPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape11: TQRShape
        Left = 796
        Top = 22
        Width = 5
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1504.345238095238000000
          41.577380952380950000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel25: TQRLabel
        Left = 804
        Top = 26
        Width = 113
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1519.464285714286000000
          49.136904761904770000
          213.556547619047600000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DATA DA EMISS'#195'O'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtide_dEmi: TQRDBText
        Left = 812
        Top = 38
        Width = 177
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1534.583333333333000000
          71.815476190476190000
          334.508928571428500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'ide_dEmi'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel26: TQRLabel
        Left = 4
        Top = 62
        Width = 69
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          7.559523809523811000
          117.172619047619100000
          130.401785714285700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'ENDERE'#199'O'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel27: TQRLabel
        Left = 444
        Top = 62
        Width = 108
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          839.107142857142900000
          117.172619047619100000
          204.107142857142800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'BAIRRO/DISTRITO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtenderDest_xBairro: TQRDBText
        Left = 452
        Top = 74
        Width = 203
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          854.226190476190600000
          139.851190476190500000
          383.645833333333400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderDest_xBairro'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape14: TQRShape
        Left = 661
        Top = 59
        Width = 3
        Height = 35
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          66.145833333333340000
          1249.211309523810000000
          111.502976190476200000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel28: TQRLabel
        Left = 668
        Top = 62
        Width = 31
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1262.440476190476000000
          117.172619047619100000
          58.586309523809540000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CEP'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtenderDest_CEP: TQRDBText
        Left = 676
        Top = 74
        Width = 108
        Height = 17
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1277.559523809524000000
          139.851190476190500000
          204.107142857142800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderDest_CEP'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape15: TQRShape
        Left = 797
        Top = 58
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1506.235119047619000000
          109.613095238095200000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel29: TQRLabel
        Left = 804
        Top = 62
        Width = 141
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1519.464285714286000000
          117.172619047619100000
          266.473214285714300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DATA DE ENTRADA/SAIDA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtdSaiEnt: TQRDBText
        Left = 812
        Top = 74
        Width = 177
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1534.583333333333000000
          139.851190476190500000
          334.508928571428500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'dSaiEnt'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel30: TQRLabel
        Left = 4
        Top = 98
        Width = 67
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          7.559523809523811000
          185.208333333333300000
          126.622023809523800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'MUNIC'#205'PIO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRDBText4: TQRDBText
        Left = 12
        Top = 110
        Width = 273
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          22.678571428571430000
          207.886904761904800000
          515.937500000000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderDest_xMun'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape17: TQRShape
        Left = 293
        Top = 94
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          553.735119047619100000
          177.648809523809500000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel31: TQRLabel
        Left = 300
        Top = 98
        Width = 69
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          566.964285714285700000
          185.208333333333300000
          130.401785714285700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'FONE/FAX'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtFoneFax: TQRDBText
        Left = 308
        Top = 110
        Width = 121
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          582.083333333333400000
          207.886904761904800000
          228.675595238095300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderDest_fone'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtFoneFaxPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape18: TQRShape
        Left = 437
        Top = 94
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          825.877976190476200000
          177.648809523809500000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel32: TQRLabel
        Left = 444
        Top = 98
        Width = 20
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          839.107142857142900000
          185.208333333333300000
          37.797619047619050000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'UF'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtenderDestUF: TQRDBText
        Left = 452
        Top = 110
        Width = 32
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          854.226190476190600000
          207.886904761904800000
          60.476190476190480000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderDest_UF'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape19: TQRShape
        Left = 517
        Top = 94
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          977.068452380952600000
          177.648809523809500000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel33: TQRLabel
        Left = 524
        Top = 98
        Width = 132
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          990.297619047619100000
          185.208333333333300000
          249.464285714285700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'INSCRI'#199#195'O ESTADUAL'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtDestIE: TQRDBText
        Left = 532
        Top = 110
        Width = 241
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1005.416666666667000000
          207.886904761904800000
          455.461309523809500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'dest_IE'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape20: TQRShape
        Left = 797
        Top = 94
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1506.235119047619000000
          177.648809523809500000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel34: TQRLabel
        Left = 804
        Top = 98
        Width = 141
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1519.464285714286000000
          185.208333333333300000
          266.473214285714300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'HORA DE ENTRADA/SA'#205'DA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel35: TQRLabel
        Left = 4
        Top = 134
        Width = 46
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          7.559523809523811000
          253.244047619047600000
          86.934523809523810000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = True
        AutoStretch = False
        Caption = 'FATURA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel36: TQRLabel
        Left = 4
        Top = 230
        Width = 181
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          7.559523809523811000
          434.672619047619100000
          342.068452380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'C'#193'LCULO DO IMPOSTO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel37: TQRLabel
        Left = 4
        Top = 252
        Width = 158
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          7.559523809523811000
          476.250000000000000000
          298.601190476190500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'BASE DE C'#193'LCULO DO ICMS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtCalIcmBas: TQRDBText
        Left = 12
        Top = 264
        Width = 185
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          22.678571428571430000
          498.928571428571400000
          349.627976190476200000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'ICMSTot_vBC'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape23: TQRShape
        Left = 293
        Top = 248
        Width = 3
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095240000
          553.735119047619100000
          468.690476190476300000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel38: TQRLabel
        Left = 300
        Top = 252
        Width = 95
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          566.964285714285700000
          476.250000000000000000
          179.538690476190500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DO ICMS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtvICMS: TQRDBText
        Left = 308
        Top = 264
        Width = 109
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          582.083333333333400000
          498.928571428571400000
          205.997023809523800000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vICMS'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape24: TQRShape
        Left = 420
        Top = 248
        Width = 5
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095240000
          793.750000000000000000
          468.690476190476300000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel39: TQRLabel
        Left = 429
        Top = 252
        Width = 193
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          810.758928571428600000
          476.250000000000000000
          364.747023809523900000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'BASE DE C'#193'LCULO DO ICMS SUBSTIT.'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtICMSSUB: TQRDBText
        Left = 432
        Top = 264
        Width = 188
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          816.428571428571400000
          498.928571428571400000
          355.297619047619000000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vBCST'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape25: TQRShape
        Left = 625
        Top = 248
        Width = 3
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095240000
          1181.175595238095000000
          468.690476190476300000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel40: TQRLabel
        Left = 632
        Top = 252
        Width = 181
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1194.404761904762000000
          476.250000000000000000
          342.068452380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DO ICMS SUBSTITUI'#199#195'O'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtvICMSSUB: TQRDBText
        Left = 640
        Top = 264
        Width = 189
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1209.523809523810000000
          498.928571428571400000
          357.187500000000000000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vST'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape26: TQRShape
        Left = 833
        Top = 248
        Width = 3
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095240000
          1574.270833333333000000
          468.690476190476300000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel41: TQRLabel
        Left = 840
        Top = 252
        Width = 159
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1587.500000000000000000
          476.250000000000000000
          300.491071428571500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR TOTAL DOS PRODUTOS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtProdValTot: TQRDBText
        Left = 848
        Top = 264
        Width = 145
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1602.619047619048000000
          498.928571428571400000
          274.032738095238100000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vProd'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape27: TQRShape
        Left = 0
        Top = 285
        Width = 1005
        Height = 36
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          68.035714285714290000
          0.000000000000000000
          538.616071428571500000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRLabel42: TQRLabel
        Left = 4
        Top = 288
        Width = 104
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          7.559523809523811000
          544.285714285714300000
          196.547619047619100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DO FRETE'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtValFrete: TQRDBText
        Left = 12
        Top = 300
        Width = 129
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          22.678571428571430000
          566.964285714285700000
          243.794642857142800000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vFrete'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape28: TQRShape
        Left = 145
        Top = 284
        Width = 3
        Height = 36
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          68.035714285714290000
          274.032738095238100000
          536.726190476190600000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel43: TQRLabel
        Left = 152
        Top = 288
        Width = 118
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          287.261904761904800000
          544.285714285714300000
          223.005952380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DO SEGURO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtvSeg: TQRDBText
        Left = 160
        Top = 300
        Width = 125
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          302.380952380952400000
          566.964285714285700000
          236.235119047619100000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vSeg'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape29: TQRShape
        Left = 293
        Top = 284
        Width = 3
        Height = 36
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          68.035714285714290000
          553.735119047619100000
          536.726190476190600000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel44: TQRLabel
        Left = 300
        Top = 288
        Width = 70
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          566.964285714285700000
          544.285714285714300000
          132.291666666666700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DESCONTO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtvDesc: TQRDBText
        Left = 308
        Top = 300
        Width = 109
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          582.083333333333400000
          566.964285714285700000
          205.997023809523800000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'ICMSTot_vDesc'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape30: TQRShape
        Left = 420
        Top = 284
        Width = 5
        Height = 36
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          68.035714285714290000
          793.750000000000000000
          536.726190476190600000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel45: TQRLabel
        Left = 424
        Top = 288
        Width = 189
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          801.309523809524000000
          544.285714285714300000
          357.187500000000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'OUTRAS DESPESAS ACESS'#211'RIAS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtvOutro: TQRDBText
        Left = 432
        Top = 300
        Width = 189
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          816.428571428571400000
          566.964285714285700000
          357.187500000000000000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vOutro'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape31: TQRShape
        Left = 625
        Top = 284
        Width = 3
        Height = 36
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          68.035714285714290000
          1181.175595238095000000
          536.726190476190600000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel46: TQRLabel
        Left = 632
        Top = 288
        Width = 81
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1194.404761904762000000
          544.285714285714300000
          153.080357142857200000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DO IPI'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtvIPI: TQRDBText
        Left = 640
        Top = 300
        Width = 189
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1209.523809523810000000
          566.964285714285700000
          357.187500000000000000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vIPI'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape32: TQRShape
        Left = 833
        Top = 284
        Width = 3
        Height = 36
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          68.035714285714290000
          1574.270833333333000000
          536.726190476190600000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object lbNFValTot: TQRLabel
        Left = 840
        Top = 288
        Width = 161
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1587.500000000000000000
          544.285714285714300000
          304.270833333333400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR TOTAL DA NOTA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtvNF: TQRDBText
        Left = 848
        Top = 300
        Width = 145
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1602.619047619048000000
          566.964285714285700000
          274.032738095238100000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vNF'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel47: TQRLabel
        Left = 4
        Top = 324
        Width = 371
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          7.559523809523811000
          612.321428571428600000
          701.145833333333400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'TRANSPORTADOR/VOLUMES TRANSPORTADOS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel48: TQRLabel
        Left = 4
        Top = 346
        Width = 88
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          7.559523809523811000
          653.898809523809500000
          166.309523809523800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'RAZ'#195'O SOCIAL'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qttransporta_xNome: TQRDBText
        Left = 12
        Top = 362
        Width = 337
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          22.678571428571430000
          684.136904761904800000
          636.889880952381100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'xNome'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape34: TQRShape
        Left = 360
        Top = 342
        Width = 5
        Height = 41
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          77.485119047619050000
          680.357142857142900000
          646.339285714285700000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel49: TQRLabel
        Left = 364
        Top = 346
        Width = 102
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          23.151041666666670000
          687.916666666666800000
          653.190104166666800000
          193.476562500000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'FRETE POR CONTA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel50: TQRLabel
        Left = 372
        Top = 358
        Width = 91
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          703.035714285714300000
          676.577380952380900000
          171.979166666666700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '0 - EMITENTE'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -5
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 4
      end
      object QRLabel51: TQRLabel
        Left = 372
        Top = 370
        Width = 92
        Height = 10
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          18.898809523809530000
          703.035714285714200000
          699.255952380952400000
          173.869047619047600000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '1 - DESTINAT'#193'RIO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -5
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 4
      end
      object QRShape35: TQRShape
        Left = 469
        Top = 346
        Width = 30
        Height = 32
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          61.184895833333340000
          886.354166666666600000
          654.843750000000000000
          56.223958333333340000)
        Shape = qrsRectangle
        VertAdjust = 0
      end
      object QRShape36: TQRShape
        Left = 500
        Top = 342
        Width = 5
        Height = 41
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          77.485119047619050000
          944.940476190476300000
          646.339285714285700000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel52: TQRLabel
        Left = 508
        Top = 346
        Width = 83
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          960.059523809524000000
          653.898809523809500000
          156.860119047619000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'C'#211'DIGO ANTF'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtCodANTT: TQRDBText
        Left = 512
        Top = 362
        Width = 109
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          967.619047619047700000
          684.136904761904800000
          205.997023809523800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'veicTransp_RNTC'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape37: TQRShape
        Left = 625
        Top = 342
        Width = 3
        Height = 41
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          77.485119047619050000
          1181.175595238095000000
          646.339285714285700000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel53: TQRLabel
        Left = 632
        Top = 346
        Width = 116
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1194.404761904762000000
          653.898809523809500000
          219.226190476190500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'PLACA DO VE'#205'CULO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtPlaca: TQRDBText
        Left = 648
        Top = 362
        Width = 104
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          33.072916666666670000
          1225.351562500000000000
          684.609375000000000000
          196.783854166666700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'veicTransp_placa'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape38: TQRShape
        Left = 752
        Top = 342
        Width = 5
        Height = 41
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          77.485119047619050000
          1421.190476190476000000
          646.339285714285700000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel54: TQRLabel
        Left = 760
        Top = 346
        Width = 21
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1436.309523809524000000
          653.898809523809500000
          39.687500000000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'UF'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtTransUF: TQRDBText
        Left = 764
        Top = 362
        Width = 29
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1443.869047619048000000
          684.136904761904800000
          54.806547619047620000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'veicTransp_UF'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel55: TQRLabel
        Left = 800
        Top = 344
        Width = 60
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1511.904761904762000000
          650.119047619047700000
          113.392857142857100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CNPJ/CPF'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qttransporta_CNPJ: TQRDBText
        Left = 808
        Top = 358
        Width = 181
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1527.023809523810000000
          676.577380952380900000
          342.068452380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'CNPJ'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel56: TQRLabel
        Left = 4
        Top = 386
        Width = 66
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          7.559523809523811000
          729.494047619047700000
          124.732142857142800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'ENDERE'#199'O'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtxEnder: TQRDBText
        Left = 12
        Top = 398
        Width = 420
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          33.072916666666670000
          23.151041666666670000
          752.408854166666800000
          793.750000000000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'xEnder'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape41: TQRShape
        Left = 440
        Top = 382
        Width = 4
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          831.547619047619200000
          721.934523809523800000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel57: TQRLabel
        Left = 448
        Top = 386
        Width = 66
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          846.666666666666900000
          729.494047619047700000
          124.732142857142800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'MUNIC'#205'PIO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qrtransporta_xMun: TQRDBText
        Left = 460
        Top = 398
        Width = 265
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          869.345238095238100000
          752.172619047619200000
          500.818452380952300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'transporta_xMun'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape42: TQRShape
        Left = 752
        Top = 382
        Width = 5
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1421.190476190476000000
          721.934523809523800000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel58: TQRLabel
        Left = 760
        Top = 386
        Width = 20
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1436.309523809524000000
          729.494047619047700000
          37.797619047619050000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'UF'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qttransporta_UF: TQRDBText
        Left = 764
        Top = 398
        Width = 28
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1443.869047619048000000
          752.172619047619200000
          52.916666666666680000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'transporta_UF'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel59: TQRLabel
        Left = 800
        Top = 386
        Width = 130
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1511.904761904762000000
          729.494047619047700000
          245.684523809523800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'INSCRI'#199#195'O ESTADUAL'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRDBText1: TQRDBText
        Left = 808
        Top = 397
        Width = 181
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1527.023809523810000000
          750.282738095238300000
          342.068452380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'IE'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel60: TQRLabel
        Left = 8
        Top = 424
        Width = 80
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          15.119047619047620000
          801.309523809524000000
          151.190476190476200000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'QUANTIDADE'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtQuantidade: TQRDBText
        Left = 16
        Top = 439
        Width = 119
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          30.238095238095240000
          829.657738095238100000
          224.895833333333300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsVolumesTransportados
        DataField = 'qVol'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape45: TQRShape
        Left = 136
        Top = 421
        Width = 5
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095240000
          257.023809523809500000
          795.639880952381100000
          9.449404761904762000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel61: TQRLabel
        Left = 140
        Top = 424
        Width = 49
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          264.583333333333400000
          801.309523809524000000
          92.604166666666680000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'ESP'#201'CIE'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtEspecie: TQRDBText
        Left = 148
        Top = 439
        Width = 125
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          279.702380952381000000
          829.657738095238100000
          236.235119047619100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsVolumesTransportados
        DataField = 'esp'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape46: TQRShape
        Left = 280
        Top = 421
        Width = 4
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095240000
          529.166666666666700000
          795.639880952381100000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel62: TQRLabel
        Left = 288
        Top = 424
        Width = 38
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          544.285714285714300000
          801.309523809524000000
          71.815476190476190000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'MARCA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtMarca: TQRDBText
        Left = 296
        Top = 439
        Width = 136
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          559.404761904761900000
          829.657738095238100000
          257.023809523809500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsVolumesTransportados
        DataField = 'marca'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape47: TQRShape
        Left = 440
        Top = 420
        Width = 4
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          831.547619047618900000
          793.750000000000000000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel63: TQRLabel
        Left = 448
        Top = 424
        Width = 80
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          846.666666666666900000
          801.309523809524000000
          151.190476190476200000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'NUMERA'#199#195'O'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtNumeracao: TQRDBText
        Left = 460
        Top = 439
        Width = 105
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          869.345238095238100000
          829.657738095238100000
          198.437500000000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsVolumesTransportados
        DataField = 'nVol'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape48: TQRShape
        Left = 569
        Top = 420
        Width = 3
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1075.342261904762000000
          793.750000000000000000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel64: TQRLabel
        Left = 576
        Top = 424
        Width = 77
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1088.571428571429000000
          801.309523809524000000
          145.520833333333300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'PESO BRUTO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtPesoBruto: TQRDBText
        Left = 584
        Top = 439
        Width = 181
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1103.690476190476000000
          829.657738095238100000
          342.068452380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsVolumesTransportados
        DataField = 'pesoB'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel65: TQRLabel
        Left = 800
        Top = 424
        Width = 84
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1511.904761904762000000
          801.309523809524000000
          158.750000000000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'PESO L'#205'QUIDO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtPesoLiquido: TQRDBText
        Left = 808
        Top = 439
        Width = 181
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1527.023809523810000000
          829.657738095238100000
          342.068452380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsVolumesTransportados
        DataField = 'pesoL'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel90: TQRLabel
        Left = 357
        Top = 156
        Width = 144
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          674.687500000000000000
          294.821428571428500000
          272.142857142857200000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'N'#218'MERO DA FATURA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel92: TQRLabel
        Left = 583
        Top = 156
        Width = 145
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1101.800595238095000000
          294.821428571428600000
          274.032738095238100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VENCIMENTO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel93: TQRLabel
        Left = 796
        Top = 156
        Width = 145
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1504.345238095238000000
          294.821428571428600000
          274.032738095238100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DA FATURA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRDBText2: TQRDBText
        Left = 12
        Top = 74
        Width = 417
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          33.072916666666670000
          23.151041666666670000
          140.559895833333300000
          788.789062500000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderDest_xLgr'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = QRDBText2Print
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel66: TQRLabel
        Left = 4
        Top = 460
        Width = 248
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          7.559523809523811000
          869.345238095238100000
          468.690476190476300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DADOS DO PRODUTO/SERVI'#199'OS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel67: TQRLabel
        Left = 32
        Top = 482
        Width = 65
        Height = 15
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          28.348214285714280000
          60.476190476190480000
          910.922619047619100000
          122.842261904761900000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'C'#211'DIGO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel68: TQRLabel
        Left = 128
        Top = 482
        Width = 225
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          241.904761904761900000
          910.922619047619100000
          425.223214285714300000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DESCRI'#199#195'O DO PRODUTO / SERVI'#199'O'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel69: TQRLabel
        Left = 362
        Top = 482
        Width = 61
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          684.136904761904800000
          910.922619047619100000
          115.282738095238100000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'NCM SH'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel70: TQRLabel
        Left = 433
        Top = 482
        Width = 25
        Height = 24
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          45.357142857142850000
          818.318452380952400000
          910.922619047619100000
          47.247023809523810000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CST'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel71: TQRLabel
        Left = 468
        Top = 482
        Width = 29
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          884.464285714285700000
          910.922619047619100000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CFOP'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel72: TQRLabel
        Left = 508
        Top = 482
        Width = 29
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          960.059523809524000000
          910.922619047619100000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'UNID.'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel73: TQRLabel
        Left = 546
        Top = 482
        Width = 53
        Height = 24
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          45.357142857142850000
          1031.875000000000000000
          910.922619047619100000
          100.163690476190500000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'QTD'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel74: TQRLabel
        Left = 609
        Top = 482
        Width = 61
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          1150.937500000000000000
          910.922619047619100000
          115.282738095238100000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR UNIT'#193'RIO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel75: TQRLabel
        Left = 678
        Top = 482
        Width = 65
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          1281.339285714286000000
          910.922619047619100000
          122.842261904761900000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR TOTAL'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel76: TQRLabel
        Left = 752
        Top = 482
        Width = 53
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          1421.190476190476000000
          910.922619047619100000
          100.163690476190500000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'BC ICMS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel77: TQRLabel
        Left = 814
        Top = 482
        Width = 50
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          1538.363095238095000000
          910.922619047619100000
          94.494047619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR ICMS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel78: TQRLabel
        Left = 872
        Top = 482
        Width = 57
        Height = 22
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          41.577380952380950000
          1647.976190476191000000
          910.922619047619100000
          107.723214285714300000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR IPI'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel79: TQRLabel
        Left = 936
        Top = 482
        Width = 29
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          1768.928571428571000000
          910.922619047619100000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'ALIQ. ICMS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel80: TQRLabel
        Left = 972
        Top = 482
        Width = 29
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          1836.964285714286000000
          910.922619047619100000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'ALIQ. IPI'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRDBText9: TQRDBText
        Left = 8
        Top = 158
        Width = 345
        Height = 64
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          120.952380952381000000
          15.119047619047620000
          298.601190476190500000
          652.008928571428600000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = True
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vLiq'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = QRDBText9Print
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel5: TQRLabel
        Left = 472
        Top = 352
        Width = 22
        Height = 20
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          38.033854166666670000
          892.968750000000000000
          664.765625000000000000
          41.341145833333340000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '0'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = QRLabel5Print
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 8
      end
      object QRShape87: TQRShape
        Left = 354
        Top = 152
        Width = 3
        Height = 76
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          143.630952380952400000
          669.017857142857100000
          287.261904761904800000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtFatPnsNum002: TQRLabel
        Left = 436
        Top = 170
        Width = 70
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333400000
          823.988095238095400000
          321.279761904761900000
          132.291666666666700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'Numero Fatura'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qlvLiq01: TQRLabel
        Left = 795
        Top = 170
        Width = 68
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333400000
          1502.455357142857000000
          321.279761904761900000
          128.511904761904800000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DA FATURA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qlvLiq02: TQRLabel
        Left = 864
        Top = 170
        Width = 68
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333300000
          1632.857142857143000000
          321.279761904761900000
          128.511904761904800000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DA FATURA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qlfat_vDesc02: TQRLabel
        Left = 651
        Top = 170
        Width = 70
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333400000
          1230.312500000000000000
          321.279761904761900000
          132.291666666666700000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VENCIMENTO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qlfat_vDesc01: TQRLabel
        Left = 582
        Top = 170
        Width = 68
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333300000
          1099.910714285714000000
          321.279761904761900000
          128.511904761904800000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VENCIMENTO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtFatPnsNum001: TQRLabel
        Left = 357
        Top = 170
        Width = 76
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333400000
          674.687500000000000000
          321.279761904761900000
          143.630952380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'Numero Fatura'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtFatPnsNum003: TQRLabel
        Left = 509
        Top = 170
        Width = 70
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333400000
          961.949404761904800000
          321.279761904761900000
          132.291666666666700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'Numero Fatura'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qlfat_vDesc03: TQRLabel
        Left = 722
        Top = 170
        Width = 68
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333300000
          1364.494047619048000000
          321.279761904761900000
          128.511904761904800000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VENCIMENTO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qlvLiq03: TQRLabel
        Left = 935
        Top = 170
        Width = 68
        Height = 56
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          105.833333333333300000
          1767.038690476190000000
          321.279761904761900000
          128.511904761904800000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DA FATURA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRShape102: TQRShape
        Left = 433
        Top = 171
        Width = 3
        Height = 57
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          107.723214285714300000
          818.318452380952400000
          323.169642857142800000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape103: TQRShape
        Left = 507
        Top = 171
        Width = 3
        Height = 57
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          107.723214285714300000
          958.169642857142900000
          323.169642857142900000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape104: TQRShape
        Left = 650
        Top = 171
        Width = 3
        Height = 57
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          107.723214285714300000
          1228.422619047619000000
          323.169642857142900000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape105: TQRShape
        Left = 719
        Top = 171
        Width = 3
        Height = 57
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          107.723214285714300000
          1358.824404761905000000
          323.169642857142900000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape106: TQRShape
        Left = 863
        Top = 171
        Width = 3
        Height = 57
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          107.723214285714300000
          1630.967261904762000000
          323.169642857142900000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape107: TQRShape
        Left = 932
        Top = 171
        Width = 3
        Height = 57
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          107.723214285714300000
          1761.369047619048000000
          323.169642857142900000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape54: TQRShape
        Left = 356
        Top = 478
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          672.797619047619200000
          903.363095238095400000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape53: TQRShape
        Left = 123
        Top = 480
        Width = 3
        Height = 32
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          60.476190476190480000
          232.455357142857200000
          907.142857142857100000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRDBText11: TQRDBText
        Left = 812
        Top = 111
        Width = 177
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1534.583333333333000000
          209.776785714285700000
          334.508928571428500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'hSaiEnt'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = QRDBText11Print
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
    end
    object qbCanhotoDaNota: TQRBand
      Left = 53
      Top = 26
      Width = 1005
      Height = 90
      Frame.Color = clBlack
      Frame.DrawTop = False
      Frame.DrawBottom = False
      Frame.DrawLeft = False
      Frame.DrawRight = False
      AlignToBottom = False
      BeforePrint = qbCanhotoDaNotaBeforePrint
      Color = clWhite
      TransparentBand = False
      ForceNewColumn = False
      ForceNewPage = False
      Size.Values = (
        170.089285714285700000
        1899.330357142857000000)
      PreCaluculateBandHeight = False
      KeepOnOnePage = False
      BandType = rbPageHeader
      object QRShape84: TQRShape
        Left = 0
        Top = 28
        Width = 788
        Height = 7
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          13.229166666666670000
          0.000000000000000000
          52.916666666666680000
          1489.226190476191000000)
        Shape = qrsHorLine
        VertAdjust = 0
      end
      object shNfeNum: TQRShape
        Left = 786
        Top = 2
        Width = 3
        Height = 81
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          153.080357142857200000
          1485.446428571429000000
          3.779761904761905000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape85: TQRShape
        Left = 185
        Top = 33
        Width = 2
        Height = 48
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          90.714285714285710000
          349.627976190476200000
          62.366071428571430000
          3.779761904761905000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape86: TQRShape
        Left = 0
        Top = 80
        Width = 1005
        Height = 5
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          9.449404761904763000
          0.000000000000000000
          151.190476190476200000
          1899.330357142857000000)
        Shape = qrsHorLine
        VertAdjust = 0
      end
      object QRLabel4: TQRLabel
        Left = 5
        Top = 35
        Width = 136
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          9.449404761904763000
          66.145833333333340000
          257.023809523809500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'Data de Recebimento'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel6: TQRLabel
        Left = 193
        Top = 35
        Width = 253
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          364.747023809523800000
          66.145833333333340000
          478.139880952381000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'Identifica'#231#227'o e assinatura do recebedor'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel7: TQRLabel
        Left = 5
        Top = 7
        Width = 76
        Height = 21
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          39.687500000000000000
          9.449404761904763000
          13.229166666666670000
          143.630952380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'Recebemos de '
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel8: TQRLabel
        Left = 441
        Top = 7
        Width = 339
        Height = 21
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          39.687500000000000000
          833.437500000000000000
          13.229166666666670000
          640.669642857142900000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 
          'os produtos e/ou servi'#231'os constantes da nota fiscal indicada ao ' +
          'lado.'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object qtSysEnt: TQRDBText
        Left = 84
        Top = 7
        Width = 355
        Height = 21
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          39.687500000000000000
          158.750000000000000000
          13.229166666666670000
          670.907738095238100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'emit_xNome'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel11: TQRLabel
        Left = 792
        Top = 7
        Width = 201
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          1496.785714285715000000
          13.229166666666670000
          379.866071428571500000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'NF-e'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 12
      end
      object QRDBText6: TQRDBText
        Left = 792
        Top = 35
        Width = 201
        Height = 22
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          41.577380952380950000
          1496.785714285715000000
          66.145833333333340000
          379.866071428571500000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'nNF'
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        OnPrint = QRDBText6Print
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 8
      end
      object QRDBText7: TQRDBText
        Left = 792
        Top = 58
        Width = 201
        Height = 23
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          43.467261904761910000
          1496.785714285715000000
          109.613095238095200000
          379.866071428571500000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'serie'
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        OnPrint = QRDBText7Print
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 8
      end
      object QRShape8: TQRShape
        Left = 0
        Top = 88
        Width = 1006
        Height = 7
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Frame.Style = psDot
        Size.Values = (
          13.229166666666670000
          0.000000000000000000
          166.309523809523800000
          1901.220238095238000000)
        Pen.Style = psDot
        Shape = qrsRectangle
        VertAdjust = 0
      end
    end
    object cbIdentificacaoDaOperacao: TQRChildBand
      Left = 53
      Top = 116
      Width = 1005
      Height = 223
      Frame.Color = clBlack
      Frame.DrawTop = False
      Frame.DrawBottom = False
      Frame.DrawLeft = False
      Frame.DrawRight = False
      AlignToBottom = False
      Color = clWhite
      TransparentBand = False
      ForceNewColumn = False
      ForceNewPage = False
      Size.Values = (
        421.443452380952400000
        1899.330357142857000000)
      PreCaluculateBandHeight = False
      KeepOnOnePage = False
      ParentBand = qbCanhotoDaNota
      PrintOrder = cboAfterParent
      object QRShape109: TQRShape
        Left = 557
        Top = 145
        Width = 448
        Height = 40
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          75.595238095238090000
          1052.663690476190000000
          274.032738095238100000
          846.666666666666600000)
        Shape = qrsRectangle
        VertAdjust = 0
      end
      object QRShape5: TQRShape
        Left = 1
        Top = 184
        Width = 1004
        Height = 38
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          1.889880952380952000
          347.738095238095200000
          1897.440476190476000000)
        Shape = qrsRectangle
        VertAdjust = 0
      end
      object QRShape2: TQRShape
        Left = 0
        Top = 4
        Width = 1005
        Height = 141
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          266.473214285714300000
          0.000000000000000000
          7.559523809523809000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape12: TQRShape
        Left = 428
        Top = 4
        Width = 129
        Height = 141
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          266.473214285714300000
          808.869047619047700000
          7.559523809523811000
          243.794642857142800000)
        Shape = qrsRectangle
        VertAdjust = 0
      end
      object QRShape6: TQRShape
        Left = 196
        Top = 185
        Width = 3
        Height = 36
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          68.035714285714290000
          370.416666666666700000
          349.627976190476200000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape7: TQRShape
        Left = 405
        Top = 185
        Width = 2
        Height = 36
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          68.035714285714290000
          765.401785714285700000
          349.627976190476200000
          3.779761904761905000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape4: TQRShape
        Left = 510
        Top = 61
        Width = 43
        Height = 24
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          45.357142857142850000
          963.839285714285700000
          115.282738095238100000
          81.264880952380950000)
        Shape = qrsRectangle
        VertAdjust = 0
      end
      object QRShape1: TQRShape
        Left = 0
        Top = 145
        Width = 557
        Height = 39
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          73.705357142857140000
          0.000000000000000000
          274.032738095238100000
          1052.663690476190000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object qtSysCliInsEst: TQRDBText
        Left = 7
        Top = 202
        Width = 183
        Height = 17
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          13.229166666666670000
          381.755952380952400000
          345.848214285714300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'emit_IE'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object qtSysCliCnp: TQRDBText
        Left = 411
        Top = 201
        Width = 138
        Height = 17
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          776.741071428571400000
          379.866071428571500000
          260.803571428571500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'emit_CNPJ'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object qtSysNopNom: TQRDBText
        Left = 8
        Top = 164
        Width = 463
        Height = 17
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          15.119047619047620000
          309.940476190476200000
          875.014880952381100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'natOp'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel17: TQRLabel
        Left = 4
        Top = 187
        Width = 175
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          7.559523809523811000
          353.407738095238100000
          330.729166666666700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'INSCRI'#199#195'O ESTADUAL'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel19: TQRLabel
        Left = 201
        Top = 187
        Width = 201
        Height = 15
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          28.348214285714280000
          379.866071428571500000
          353.407738095238100000
          379.866071428571500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'INSC ESTADUAL DO SUBST TRIBUT'#193'RIO'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtIEST: TQRDBText
        Left = 207
        Top = 201
        Width = 190
        Height = 17
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          391.205357142857100000
          379.866071428571500000
          359.077380952381000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'IEST'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRLabel21: TQRLabel
        Left = 566
        Top = 187
        Width = 351
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1069.672619047619000000
          353.407738095238100000
          663.348214285714300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'PROTOCOLO DE AUTORIZA'#199#195'O DE USO'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtChaveAcesso: TQRDBText
        Left = 570
        Top = 127
        Width = 385
        Height = 17
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1077.232142857143000000
          240.014880952381000000
          727.604166666666600000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'infNFe_Id'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtChaveAcessoPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object qtFatNsuNum: TQRDBText
        Left = 466
        Top = 88
        Width = 85
        Height = 15
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          28.348214285714280000
          880.684523809523800000
          166.309523809523800000
          160.639880952381000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'nNF'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '000,000'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object qtSysCliRazSoc: TQRDBText
        Left = 142
        Top = 9
        Width = 276
        Height = 47
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          88.824404761904770000
          268.363095238095200000
          17.008928571428570000
          521.607142857142800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'emit_xNome'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -12
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 9
      end
      object qtSysCidNom: TQRDBText
        Left = 219
        Top = 98
        Width = 204
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          413.883928571428600000
          185.208333333333300000
          385.535714285714300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderEmit_xMun'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtSysCidNomPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object qtSysCliTel: TQRDBText
        Left = 146
        Top = 120
        Width = 276
        Height = 22
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          41.577380952380950000
          275.922619047619100000
          226.785714285714300000
          521.607142857142900000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderEmit_fone'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtSysCliTelPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object qtSysCliEndBai: TQRDBText
        Left = 146
        Top = 78
        Width = 276
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          275.922619047619100000
          147.410714285714300000
          521.607142857142900000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderEmit_xBairro'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object qtenderEmit_CEP: TQRDBText
        Left = 146
        Top = 98
        Width = 71
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          275.922619047619100000
          185.208333333333300000
          134.181547619047600000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderEmit_CEP'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object qiLogomarca: TQRImage
        Left = 5
        Top = 9
        Width = 134
        Height = 134
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          253.244047619047600000
          9.449404761904762000
          17.008928571428570000
          253.244047619047600000)
        Center = True
        Stretch = True
      end
      object QRLabel1: TQRLabel
        Left = 564
        Top = 9
        Width = 437
        Height = 14
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          26.458333333333330000
          1065.892857142857000000
          17.008928571428570000
          825.877976190476200000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CONTROLE DO FISCO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel2: TQRLabel
        Left = 434
        Top = 8
        Width = 119
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          820.208333333333400000
          15.119047619047620000
          224.895833333333300000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DANFE'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 12
      end
      object QRLabel12: TQRLabel
        Left = 434
        Top = 32
        Width = 119
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          820.208333333333400000
          60.476190476190480000
          224.895833333333300000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'Documento Auxiliar da Nota Fiscal Eletr'#244'nica'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel13: TQRLabel
        Left = 434
        Top = 60
        Width = 73
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          820.208333333333400000
          113.392857142857100000
          137.961309523809500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '0 - ENTRADA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel15: TQRLabel
        Left = 445
        Top = 88
        Width = 15
        Height = 15
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          28.348214285714280000
          840.997023809523800000
          166.309523809523800000
          28.348214285714280000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = True
        AutoStretch = False
        Caption = 'N'#186'.'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel16: TQRLabel
        Left = 436
        Top = 108
        Width = 25
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          823.988095238095400000
          204.107142857142800000
          47.247023809523810000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = True
        AutoStretch = False
        Caption = 'S'#233'rie'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtFatNsuSer: TQRDBText
        Left = 466
        Top = 108
        Width = 41
        Height = 15
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          28.348214285714280000
          880.684523809523800000
          204.107142857142800000
          77.485119047619050000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'serie'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel18: TQRLabel
        Left = 434
        Top = 72
        Width = 73
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          820.208333333333400000
          136.071428571428600000
          137.961309523809500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '1 - SA'#205'DA'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtEnderEmit_xLgr: TQRDBText
        Left = 146
        Top = 58
        Width = 276
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          275.922619047619000000
          109.613095238095200000
          521.607142857142800000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        BiDiMode = bdLeftToRight
        ParentBiDiMode = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'enderEmit_xLgr'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtEnderEmit_xLgrPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel14: TQRLabel
        Left = 3
        Top = 148
        Width = 132
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          5.669642857142857000
          279.702380952381000000
          249.464285714285700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = True
        AutoStretch = False
        Caption = 'NATUREZA DA OPERA'#199#195'O'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel20: TQRLabel
        Left = 410
        Top = 188
        Width = 28
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          774.851190476190500000
          355.297619047619000000
          52.916666666666680000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = True
        AutoStretch = False
        Caption = 'CNPJ'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRSysData1: TQRSysData
        Left = 434
        Top = 129
        Width = 121
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          820.208333333333400000
          243.794642857142800000
          228.675595238095200000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        Color = clWhite
        Data = qrsPageNumber
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = QRSysData1Print
        ParentFont = False
        Text = 'P'#225'gina '
        Transparent = False
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel3: TQRLabel
        Left = 518
        Top = 63
        Width = 27
        Height = 20
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          37.797619047619050000
          978.958333333333400000
          119.062500000000000000
          51.026785714285720000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '1'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = QRLabel3Print
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 8
      end
      object qiCodigoBarras: TQRImage
        Left = 584
        Top = 24
        Width = 403
        Height = 57
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          107.723214285714300000
          1103.690476190476000000
          45.357142857142850000
          761.622023809523800000)
      end
      object QRLabel106: TQRLabel
        Left = 566
        Top = 110
        Width = 391
        Height = 13
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          24.568452380952380000
          1069.672619047619000000
          207.886904761904800000
          738.943452380952300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CHAVE DE ACESSO DA NF-e P/ CONSULTA DE AUTENTICIDADE NO SITE'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRShape108: TQRShape
        Left = 556
        Top = 185
        Width = 2
        Height = 37
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          69.925595238095230000
          1050.773809523810000000
          349.627976190476200000
          3.779761904761905000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRnProt: TQRLabel
        Left = 570
        Top = 200
        Width = 52
        Height = 20
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          37.797619047619050000
          1077.232142857143000000
          377.976190476190500000
          98.273809523809540000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = True
        AutoStretch = False
        Caption = 'QRnProt'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape110: TQRShape
        Left = 557
        Top = 105
        Width = 447
        Height = 5
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          9.449404761904762000
          1052.663690476190000000
          198.437500000000000000
          844.776785714285700000)
        Shape = qrsHorLine
        VertAdjust = 0
      end
      object QRLabel107: TQRLabel
        Left = 567
        Top = 148
        Width = 379
        Height = 33
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          62.366071428571430000
          1071.562500000000000000
          279.702380952381000000
          716.264880952380900000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 
          'Consulta de autenticidade no portal nacional da NF-e www.nfe.faz' +
          'enda.gov.br/portal ou no site da Sefaz Autorizadora'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
    end
    object qbDetalhe: TQRBand
      Left = 53
      Top = 886
      Width = 1005
      Height = 19
      Frame.Color = clBlack
      Frame.DrawTop = False
      Frame.DrawBottom = False
      Frame.DrawLeft = False
      Frame.DrawRight = False
      Frame.Style = psInsideFrame
      AlignToBottom = False
      Color = clWhite
      TransparentBand = False
      ForceNewColumn = False
      ForceNewPage = False
      Size.Values = (
        35.907738095238090000
        1899.330357142857000000)
      PreCaluculateBandHeight = False
      KeepOnOnePage = False
      BandType = rbDetail
      object qsDetDiv13: TQRShape
        Tag = 1000
        Left = 966
        Top = 0
        Width = 4
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1825.625000000000000000
          0.000000000000000000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtAliqIPI: TQRDBText
        Left = 972
        Top = 1
        Width = 29
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1836.964285714286000000
          1.889880952380952000
          54.806547619047620000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsItensDaNota
        DataField = 'pIPI'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '#0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qsDetDiv12: TQRShape
        Tag = 1000
        Left = 930
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1757.589285714286000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qsDetDiv11: TQRShape
        Tag = 1000
        Left = 866
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1636.636904761905000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtIPIVal: TQRDBText
        Left = 872
        Top = 1
        Width = 57
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1647.976190476191000000
          1.889880952380953000
          107.723214285714300000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsItensDaNota
        DataField = 'vIPI'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qsDetDiv10: TQRShape
        Tag = 1000
        Left = 807
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1525.133928571429000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtICMSVal: TQRLabel
        Left = 814
        Top = 1
        Width = 50
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1538.363095238095000000
          1.889880952380953000
          94.494047619047620000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '0.00'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtICMSValPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qsDetDiv9: TQRShape
        Tag = 1000
        Left = 745
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1407.961309523810000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtBasIcms: TQRLabel
        Left = 752
        Top = 1
        Width = 54
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1421.190476190476000000
          1.889880952380953000
          102.053571428571400000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '0.00'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtBasIcmsPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qsDetDiv8: TQRShape
        Tag = 1000
        Left = 672
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1270.000000000000000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtValTot: TQRDBText
        Left = 678
        Top = 1
        Width = 65
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1281.339285714286000000
          1.889880952380953000
          122.842261904761900000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsItensDaNota
        DataField = 'vProd'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.00'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qsDetDiv7: TQRShape
        Tag = 1000
        Left = 603
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1139.598214285714000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtValUnit: TQRDBText
        Left = 609
        Top = 1
        Width = 61
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1150.937500000000000000
          1.889880952380953000
          115.282738095238100000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsItensDaNota
        DataField = 'vUnCom'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.0000'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qsDetDiv6: TQRShape
        Tag = 1000
        Left = 540
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          1020.535714285714000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtQuanridade: TQRDBText
        Left = 546
        Top = 1
        Width = 53
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1031.875000000000000000
          1.889880952380953000
          100.163690476190500000)
        Alignment = taRightJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsItensDaNota
        DataField = 'qCom'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        Mask = '###,###,##0.000'
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qsDetDiv2: TQRShape
        Tag = 1000
        Left = 356
        Top = 0
        Width = 4
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          672.797619047619200000
          0.000000000000000000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qsDetDiv3: TQRShape
        Tag = 1000
        Left = 428
        Top = 0
        Width = 1
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          808.869047619047700000
          0.000000000000000000
          1.889880952380953000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qsDetDiv5: TQRShape
        Tag = 1000
        Left = 501
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          946.830357142857100000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qtNCMSH: TQRDBText
        Left = 363
        Top = 1
        Width = 61
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          686.026785714285800000
          1.889880952380953000
          115.282738095238100000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsItensDaNota
        DataField = 'NCM'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtCST: TQRLabel
        Left = 433
        Top = 1
        Width = 25
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          818.318452380952400000
          1.889880952380953000
          47.247023809523810000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '000'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtCSTPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtCFOP: TQRDBText
        Left = 468
        Top = 1
        Width = 29
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          884.464285714285700000
          1.889880952380953000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsItensDaNota
        DataField = 'CFOP'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtUnidade: TQRDBText
        Left = 508
        Top = 1
        Width = 29
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          960.059523809524000000
          1.889880952380953000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsItensDaNota
        DataField = 'uCom'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel10: TQRLabel
        Left = 4
        Top = 1
        Width = 117
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          7.559523809523811000
          1.889880952380953000
          221.116071428571400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = True
        Caption = 'cProd'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qtEstProCodPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRAliqICMS: TQRLabel
        Left = 934
        Top = 1
        Width = 32
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1765.148809523810000000
          1.889880952380952000
          60.476190476190480000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = '0000'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = QRAliqICMSPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRShape111: TQRShape
        Left = 88
        Top = -72
        Width = 1
        Height = 38
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          166.309523809523800000
          -136.071428571428600000
          1.889880952380953000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape112: TQRShape
        Left = 312
        Top = -72
        Width = 4
        Height = 38
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          71.815476190476190000
          589.642857142857100000
          -136.071428571428600000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qsDetDiv1: TQRShape
        Tag = 1000
        Left = 123
        Top = 0
        Width = 3
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          232.455357142857200000
          0.000000000000000000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object qrProdDesc: TQRLabel
        Left = 128
        Top = 1
        Width = 228
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          241.904761904761900000
          1.889880952380953000
          430.892857142857100000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = True
        Caption = 'xProd'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = qrProdDescPrint
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qsDetDiv4: TQRShape
        Tag = 1000
        Left = 461
        Top = 0
        Width = 5
        Height = 17
        Enabled = False
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          32.127976190476190000
          871.235119047619200000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
    end
    object qbCalculoIssqn: TQRBand
      Left = 53
      Top = 905
      Width = 1005
      Height = 63
      Frame.Color = clBlack
      Frame.DrawTop = True
      Frame.DrawBottom = False
      Frame.DrawLeft = False
      Frame.DrawRight = False
      AlignToBottom = False
      BeforePrint = qbCalculoIssqnBeforePrint
      Color = clWhite
      TransparentBand = False
      ForceNewColumn = False
      ForceNewPage = False
      Size.Values = (
        119.062500000000000000
        1899.330357142857000000)
      PreCaluculateBandHeight = False
      KeepOnOnePage = False
      BandType = rbPageFooter
      object QRShape66: TQRShape
        Left = 0
        Top = 21
        Width = 1005
        Height = 40
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          75.595238095238110000
          0.000000000000000000
          39.687500000000000000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRLabel81: TQRLabel
        Left = 4
        Top = 3
        Width = 157
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          7.559523809523811000
          5.669642857142857000
          296.711309523809600000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'C'#193'LCULO DO ISSQN'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel82: TQRLabel
        Left = 3
        Top = 24
        Width = 131
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          29.765625000000000000
          6.614583333333332000
          46.302083333333340000
          248.046875000000000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'INSCRI'#199#195'O MUNICIPAL'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRDBText3: TQRDBText
        Left = 14
        Top = 39
        Width = 358
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.726562500000000000
          26.458333333333330000
          72.760416666666680000
          676.341145833333500000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'IM'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape80: TQRShape
        Left = 377
        Top = 21
        Width = 2
        Height = 40
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          75.595238095238110000
          712.485119047619100000
          39.687500000000000000
          3.779761904761905000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel83: TQRLabel
        Left = 382
        Top = 24
        Width = 169
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          23.151041666666670000
          722.643229166666600000
          46.302083333333340000
          319.153645833333400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR TOTAL DOS SERVI'#199'OS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRDBText5: TQRDBText
        Left = 393
        Top = 39
        Width = 231
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.726562500000000000
          742.486979166666800000
          72.760416666666680000
          436.562499999999900000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'ISSQNtot_vServ'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape81: TQRShape
        Left = 630
        Top = 21
        Width = 5
        Height = 44
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          83.154761904761910000
          1190.625000000000000000
          39.687500000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel84: TQRLabel
        Left = 640
        Top = 24
        Width = 211
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          23.151041666666670000
          1210.468750000000000000
          46.302083333333340000
          398.528645833333300000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'BASE DE C'#193'LCULO DO ISSQN'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object qtvBC: TQRDBText
        Left = 651
        Top = 38
        Width = 202
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1230.312500000000000000
          71.815476190476190000
          381.755952380952400000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'ISSQNtot_vBC'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
      object QRShape82: TQRShape
        Left = 856
        Top = 21
        Width = 5
        Height = 40
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          75.595238095238110000
          1617.738095238095000000
          39.687500000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel85: TQRLabel
        Left = 864
        Top = 24
        Width = 102
        Height = 12
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          22.678571428571430000
          1632.857142857143000000
          45.357142857142850000
          192.767857142857200000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR DO ISSQN'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRDBText8: TQRDBText
        Left = 875
        Top = 38
        Width = 102
        Height = 18
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          34.017857142857150000
          1653.645833333333000000
          71.815476190476190000
          192.767857142857200000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'vISS'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
    end
    object cbDadosAdicionais: TQRChildBand
      Left = 53
      Top = 968
      Width = 1005
      Height = 201
      Frame.Color = clBlack
      Frame.DrawTop = False
      Frame.DrawBottom = False
      Frame.DrawLeft = False
      Frame.DrawRight = False
      AlignToBottom = False
      BeforePrint = cbDadosAdicionaisBeforePrint
      Color = clWhite
      TransparentBand = False
      ForceNewColumn = False
      ForceNewPage = False
      Size.Values = (
        379.866071428571500000
        1899.330357142857000000)
      PreCaluculateBandHeight = False
      KeepOnOnePage = False
      ParentBand = qbCalculoIssqn
      PrintOrder = cboAfterParent
      object QRLabel86: TQRLabel
        Left = 4
        Top = 0
        Width = 155
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          7.559523809523811000
          0.000000000000000000
          292.931547619047600000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DADOS ADICIONAIS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRLabel87: TQRLabel
        Left = 164
        Top = 4
        Width = 269
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          309.940476190476200000
          7.559523809523811000
          508.377976190476200000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'INFORMA'#199#213'ES COMPLEMENTARES'
        Color = clWhite
        Font.Charset = ANSI_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRShape83: TQRShape
        Left = 632
        Top = 0
        Width = 1
        Height = 201
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          379.866071428571500000
          1194.404761904762000000
          0.000000000000000000
          1.889880952380953000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel9: TQRLabel
        Left = 640
        Top = 0
        Width = 155
        Height = 16
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          30.238095238095240000
          1209.523809523810000000
          0.000000000000000000
          292.931547619047700000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'RESERVADO AO FISCO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -8
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = [fsBold]
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 6
      end
      object QRDBText10: TQRDBText
        Left = 6
        Top = 23
        Width = 619
        Height = 162
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          306.160714285714300000
          11.339285714285710000
          43.467261904761910000
          1169.836309523810000000)
        Alignment = taLeftJustify
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Color = clWhite
        DataSet = cdsNotaFiscal
        DataField = 'infCpl'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clBlack
        Font.Height = -9
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        OnPrint = QRDBText10Print
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 7
      end
    end
    object qbSubCabecalho: TQRBand
      Left = 53
      Top = 339
      Width = 1005
      Height = 34
      Frame.Color = clBlack
      Frame.DrawTop = False
      Frame.DrawBottom = False
      Frame.DrawLeft = False
      Frame.DrawRight = False
      AfterPrint = qbSubCabecalhoAfterPrint
      AlignToBottom = False
      BeforePrint = qbSubCabecalhoBeforePrint
      Color = clWhite
      TransparentBand = False
      ForceNewColumn = False
      ForceNewPage = False
      LinkBand = qbDetalhe
      Size.Values = (
        64.255952380952380000
        1899.330357142857000000)
      PreCaluculateBandHeight = False
      KeepOnOnePage = False
      BandType = rbColumnHeader
      object QRShape88: TQRShape
        Left = 1
        Top = 0
        Width = 1005
        Height = 33
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          62.366071428571420000
          1.889880952380953000
          0.000000000000000000
          1899.330357142857000000)
        Shape = qrsTopAndBottom
        VertAdjust = 0
      end
      object QRShape89: TQRShape
        Left = 426
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          805.089285714285800000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape90: TQRShape
        Left = 461
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          871.235119047619200000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape91: TQRShape
        Left = 540
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1020.535714285714000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape92: TQRShape
        Left = 540
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1020.535714285714000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape93: TQRShape
        Left = 603
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1139.598214285714000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape94: TQRShape
        Left = 672
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1270.000000000000000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape95: TQRShape
        Left = 745
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1407.961309523810000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape96: TQRShape
        Left = 123
        Top = 0
        Width = 3
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          232.455357142857200000
          0.000000000000000000
          5.669642857142857000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape97: TQRShape
        Left = 356
        Top = 0
        Width = 4
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          672.797619047619200000
          0.000000000000000000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel88: TQRLabel
        Left = 8
        Top = 2
        Width = 89
        Height = 23
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          43.467261904761910000
          15.119047619047620000
          3.779761904761905000
          168.199404761904800000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'C'#211'DIGO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel89: TQRLabel
        Left = 128
        Top = 2
        Width = 225
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          241.904761904761900000
          3.779761904761905000
          425.223214285714300000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'DESCRI'#199#195'O DO PRODUTO / SERVI'#199'O'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel91: TQRLabel
        Left = 362
        Top = 2
        Width = 49
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          684.136904761904800000
          3.779761904761905000
          92.604166666666680000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'NCM SH'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel94: TQRLabel
        Left = 433
        Top = 2
        Width = 25
        Height = 24
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          45.357142857142850000
          818.318452380952400000
          3.779761904761905000
          47.247023809523810000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CST'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel95: TQRLabel
        Left = 468
        Top = 2
        Width = 29
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          884.464285714285700000
          3.779761904761905000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'CFOP'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel96: TQRLabel
        Left = 508
        Top = 2
        Width = 29
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          960.059523809524000000
          3.779761904761905000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'UNID.'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel97: TQRLabel
        Left = 546
        Top = 2
        Width = 54
        Height = 24
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          45.357142857142850000
          1031.875000000000000000
          3.779761904761905000
          102.053571428571400000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'QTD'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel98: TQRLabel
        Left = 609
        Top = 2
        Width = 61
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          1150.937500000000000000
          3.779761904761905000
          115.282738095238100000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR UNIT'#193'RIO'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel99: TQRLabel
        Left = 678
        Top = 2
        Width = 58
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          1281.339285714286000000
          3.779761904761905000
          109.613095238095200000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR TOTAL'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel100: TQRLabel
        Left = 752
        Top = 2
        Width = 48
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          1421.190476190476000000
          3.779761904761905000
          90.714285714285710000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'BC ICMS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel101: TQRLabel
        Left = 814
        Top = 2
        Width = 51
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          1538.363095238095000000
          3.779761904761905000
          96.383928571428570000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR ICMS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRShape98: TQRShape
        Left = 807
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1525.133928571429000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape99: TQRShape
        Left = 866
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1636.636904761905000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel102: TQRLabel
        Left = 872
        Top = 2
        Width = 52
        Height = 22
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          41.577380952380950000
          1647.976190476191000000
          3.779761904761905000
          98.273809523809540000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'VALOR IPI'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRLabel103: TQRLabel
        Left = 936
        Top = 2
        Width = 29
        Height = 25
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          47.247023809523810000
          1768.928571428571000000
          3.779761904761905000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'ALIQ. ICMS'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRShape100: TQRShape
        Left = 930
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1757.589285714286000000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRLabel104: TQRLabel
        Left = 972
        Top = 2
        Width = 29
        Height = 27
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          51.026785714285720000
          1836.964285714286000000
          3.779761904761905000
          54.806547619047620000)
        Alignment = taCenter
        AlignToBand = False
        AutoSize = False
        AutoStretch = False
        Caption = 'ALIQ. IPI'
        Color = clWhite
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -7
        Font.Name = 'Arial'
        Font.Pitch = fpFixed
        Font.Style = []
        ParentFont = False
        Transparent = False
        WordWrap = True
        ExportAs = exptText
        FontSize = 5
      end
      object QRShape101: TQRShape
        Left = 966
        Top = 0
        Width = 4
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          1825.625000000000000000
          0.000000000000000000
          7.559523809523811000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
      object QRShape69: TQRShape
        Left = 501
        Top = 0
        Width = 5
        Height = 34
        Frame.Color = clBlack
        Frame.DrawTop = False
        Frame.DrawBottom = False
        Frame.DrawLeft = False
        Frame.DrawRight = False
        Size.Values = (
          64.255952380952380000
          946.830357142857100000
          0.000000000000000000
          9.449404761904763000)
        Shape = qrsVertLine
        VertAdjust = 0
      end
    end
    object QRLabel105: TQRLabel
      Left = 55
      Top = 1546
      Width = 498
      Height = 16
      Frame.Color = clBlack
      Frame.DrawTop = False
      Frame.DrawBottom = False
      Frame.DrawLeft = False
      Frame.DrawRight = False
      Size.Values = (
        30.238095238095240000
        103.943452380952400000
        2921.755952380952000000
        941.160714285714300000)
      Alignment = taLeftJustify
      AlignToBand = False
      AutoSize = False
      AutoStretch = False
      Caption = 'Open NFe - Servidor DANFE - v3.0.0.0 - www.rochadigital.com'
      Color = clWhite
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -7
      Font.Name = 'Arial'
      Font.Pitch = fpFixed
      Font.Style = []
      ParentFont = False
      Transparent = False
      WordWrap = True
      ExportAs = exptText
      FontSize = 5
    end
  end
  object dsFatNsu: TDataSource
    DataSet = cdsNotaFiscal
    Left = 12
    Top = 303
  end
  object cdsNotaFiscal: TClientDataSet
    Aggregates = <>
    FetchOnDemand = False
    Params = <>
    ProviderName = 'XTPNFE'
    AfterOpen = cdsNotaFiscalAfterOpen
    Left = 12
    Top = 335
    object cdsNotaFiscalversao: TStringField
      FieldName = 'versao'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalinfNFe_Id: TStringField
      FieldName = 'infNFe_Id'
      Required = True
      Size = 47
    end
    object cdsNotaFiscalcUF: TStringField
      FieldName = 'cUF'
      Size = 31
    end
    object cdsNotaFiscalcNF: TStringField
      FieldName = 'cNF'
      Size = 31
    end
    object cdsNotaFiscalnatOp: TStringField
      FieldName = 'natOp'
      Size = 60
    end
    object cdsNotaFiscalindPag: TStringField
      FieldName = 'indPag'
      Size = 31
    end
    object cdsNotaFiscalmod: TStringField
      FieldName = 'mod'
      Size = 31
    end
    object cdsNotaFiscalserie: TStringField
      FieldName = 'serie'
      Size = 31
    end
    object cdsNotaFiscalnNF: TStringField
      FieldName = 'nNF'
      Size = 31
    end
    object cdsNotaFiscalide_dEmi: TDateField
      FieldName = 'ide_dEmi'
    end
    object cdsNotaFiscaldSaiEnt: TDateField
      FieldName = 'dSaiEnt'
    end
    object cdsNotaFiscalhSaiEnt: TStringField
      FieldName = 'hSaiEnt'
      Size = 31
    end
    object cdsNotaFiscaltpNF: TStringField
      FieldName = 'tpNF'
      Size = 31
    end
    object cdsNotaFiscalcMunFG1: TStringField
      FieldName = 'cMunFG1'
      Size = 31
    end
    object cdsNotaFiscaltpImp: TStringField
      FieldName = 'tpImp'
      Size = 31
    end
    object cdsNotaFiscaltpEmis: TStringField
      FieldName = 'tpEmis'
      Size = 31
    end
    object cdsNotaFiscalcDV: TStringField
      FieldName = 'cDV'
      Size = 31
    end
    object cdsNotaFiscaltpAmb: TStringField
      FieldName = 'tpAmb'
      Size = 31
    end
    object cdsNotaFiscalfinNFe: TStringField
      FieldName = 'finNFe'
      Size = 31
    end
    object cdsNotaFiscalprocEmi: TStringField
      FieldName = 'procEmi'
      Size = 31
    end
    object cdsNotaFiscalverProc: TStringField
      FieldName = 'verProc'
    end
    object cdsNotaFiscaldhCont: TStringField
      FieldName = 'dhCont'
      Size = 31
    end
    object cdsNotaFiscalxJust: TStringField
      FieldName = 'xJust'
      Size = 31
    end
    object cdsNotaFiscalemit_CNPJ: TStringField
      FieldName = 'emit_CNPJ'
      Size = 31
    end
    object cdsNotaFiscalemit_CPF: TStringField
      FieldName = 'emit_CPF'
      Size = 31
    end
    object cdsNotaFiscalemit_xNome: TStringField
      FieldName = 'emit_xNome'
      Size = 60
    end
    object cdsNotaFiscalxFant: TStringField
      FieldName = 'xFant'
      Size = 60
    end
    object cdsNotaFiscalenderEmit_xLgr: TStringField
      FieldName = 'enderEmit_xLgr'
      Size = 60
    end
    object cdsNotaFiscalenderEmit_nro: TStringField
      FieldName = 'enderEmit_nro'
      Size = 60
    end
    object cdsNotaFiscalenderEmit_xCpl: TStringField
      FieldName = 'enderEmit_xCpl'
      Size = 60
    end
    object cdsNotaFiscalenderEmit_xBairro: TStringField
      FieldName = 'enderEmit_xBairro'
      Size = 60
    end
    object cdsNotaFiscalenderEmit_cMun: TStringField
      FieldName = 'enderEmit_cMun'
      Size = 31
    end
    object cdsNotaFiscalenderEmit_xMun: TStringField
      FieldName = 'enderEmit_xMun'
      Size = 60
    end
    object cdsNotaFiscalenderEmit_UF: TStringField
      FieldName = 'enderEmit_UF'
      Size = 31
    end
    object cdsNotaFiscalenderEmit_CEP: TStringField
      FieldName = 'enderEmit_CEP'
      Size = 31
    end
    object cdsNotaFiscalenderEmit_cPais: TStringField
      FieldName = 'enderEmit_cPais'
      Size = 31
    end
    object cdsNotaFiscalenderEmit_xPais: TStringField
      FieldName = 'enderEmit_xPais'
      Size = 31
    end
    object cdsNotaFiscalenderEmit_fone: TStringField
      FieldName = 'enderEmit_fone'
      Size = 31
    end
    object cdsNotaFiscalemit_IE: TStringField
      FieldName = 'emit_IE'
      Size = 31
    end
    object cdsNotaFiscalIEST: TStringField
      FieldName = 'IEST'
      Size = 31
    end
    object cdsNotaFiscalIM: TStringField
      FieldName = 'IM'
      Size = 15
    end
    object cdsNotaFiscalCNAE: TStringField
      FieldName = 'CNAE'
      Size = 31
    end
    object cdsNotaFiscalCRT: TStringField
      FieldName = 'CRT'
      Size = 31
    end
    object cdsNotaFiscalavulsa_CNPJ: TStringField
      FieldName = 'avulsa_CNPJ'
      Size = 31
    end
    object cdsNotaFiscalxOrgao: TStringField
      FieldName = 'xOrgao'
      Size = 60
    end
    object cdsNotaFiscalmatr: TStringField
      FieldName = 'matr'
      Size = 60
    end
    object cdsNotaFiscalxAgente: TStringField
      FieldName = 'xAgente'
      Size = 60
    end
    object cdsNotaFiscalfone: TStringField
      FieldName = 'fone'
      Size = 31
    end
    object cdsNotaFiscalavulsa_UF: TStringField
      FieldName = 'avulsa_UF'
      Size = 31
    end
    object cdsNotaFiscalnDAR: TStringField
      FieldName = 'nDAR'
      Size = 60
    end
    object cdsNotaFiscalavulsa_dEmi: TStringField
      FieldName = 'avulsa_dEmi'
      Size = 31
    end
    object cdsNotaFiscalvDAR: TStringField
      FieldName = 'vDAR'
      Size = 31
    end
    object cdsNotaFiscalrepEmi: TStringField
      FieldName = 'repEmi'
      Size = 60
    end
    object cdsNotaFiscaldPag: TStringField
      FieldName = 'dPag'
      Size = 31
    end
    object cdsNotaFiscaldest_CNPJ: TStringField
      FieldName = 'dest_CNPJ'
      Size = 31
    end
    object cdsNotaFiscaldest_CPF: TStringField
      FieldName = 'dest_CPF'
      Size = 31
    end
    object cdsNotaFiscaldest_xNome: TStringField
      FieldName = 'dest_xNome'
      Size = 60
    end
    object cdsNotaFiscalenderDest_xLgr: TStringField
      FieldName = 'enderDest_xLgr'
      Size = 60
    end
    object cdsNotaFiscalenderDest_nro: TStringField
      FieldName = 'enderDest_nro'
      Size = 60
    end
    object cdsNotaFiscalenderDest_xCpl: TStringField
      FieldName = 'enderDest_xCpl'
      Size = 60
    end
    object cdsNotaFiscalenderDest_xBairro: TStringField
      FieldName = 'enderDest_xBairro'
      Size = 60
    end
    object cdsNotaFiscalenderDest_cMun: TStringField
      FieldName = 'enderDest_cMun'
      Size = 31
    end
    object cdsNotaFiscalenderDest_xMun: TStringField
      FieldName = 'enderDest_xMun'
      Size = 60
    end
    object cdsNotaFiscalenderDest_UF: TStringField
      FieldName = 'enderDest_UF'
      Size = 31
    end
    object cdsNotaFiscalenderDest_cPais: TStringField
      FieldName = 'enderDest_cPais'
      Size = 31
    end
    object cdsNotaFiscalenderDest_xPais: TStringField
      FieldName = 'enderDest_xPais'
      Size = 31
    end
    object cdsNotaFiscalenderDest_fone: TStringField
      FieldName = 'enderDest_fone'
      Size = 31
    end
    object cdsNotaFiscaldest_IE: TStringField
      FieldName = 'dest_IE'
      Size = 31
    end
    object cdsNotaFiscalISUF: TStringField
      FieldName = 'ISUF'
      Size = 31
    end
    object cdsNotaFiscalemail: TStringField
      FieldName = 'email'
      Size = 60
    end
    object cdsNotaFiscalretirada_CNPJ: TStringField
      FieldName = 'retirada_CNPJ'
      Size = 31
    end
    object cdsNotaFiscalretirada_CPF: TStringField
      FieldName = 'retirada_CPF'
      Size = 31
    end
    object cdsNotaFiscalretirada_xLgr: TStringField
      FieldName = 'retirada_xLgr'
      Size = 60
    end
    object cdsNotaFiscalretirada_nro: TStringField
      FieldName = 'retirada_nro'
      Size = 60
    end
    object cdsNotaFiscalretirada_xCpl: TStringField
      FieldName = 'retirada_xCpl'
      Size = 60
    end
    object cdsNotaFiscalretirada_xBairro: TStringField
      FieldName = 'retirada_xBairro'
      Size = 60
    end
    object cdsNotaFiscalretirada_cMun: TStringField
      FieldName = 'retirada_cMun'
      Size = 31
    end
    object cdsNotaFiscalretirada_xMun: TStringField
      FieldName = 'retirada_xMun'
      Size = 60
    end
    object cdsNotaFiscalretirada_UF: TStringField
      FieldName = 'retirada_UF'
      Size = 31
    end
    object cdsNotaFiscalentrega_CNPJ: TStringField
      FieldName = 'entrega_CNPJ'
      Size = 31
    end
    object cdsNotaFiscalentrega_CPF: TStringField
      FieldName = 'entrega_CPF'
      Size = 31
    end
    object cdsNotaFiscalentrega_xLgr: TStringField
      FieldName = 'entrega_xLgr'
      Size = 60
    end
    object cdsNotaFiscalentrega_nro: TStringField
      FieldName = 'entrega_nro'
      Size = 60
    end
    object cdsNotaFiscalentrega_xCpl: TStringField
      FieldName = 'entrega_xCpl'
      Size = 60
    end
    object cdsNotaFiscalentrega_xBairro: TStringField
      FieldName = 'entrega_xBairro'
      Size = 60
    end
    object cdsNotaFiscalentrega_cMun: TStringField
      FieldName = 'entrega_cMun'
      Size = 31
    end
    object cdsNotaFiscalentrega_xMun: TStringField
      FieldName = 'entrega_xMun'
      Size = 60
    end
    object cdsNotaFiscalentrega_UF: TStringField
      FieldName = 'entrega_UF'
      Size = 31
    end
    object cdsNotaFiscalICMSTot_vBC: TStringField
      FieldName = 'ICMSTot_vBC'
      Size = 31
    end
    object cdsNotaFiscalvICMS: TStringField
      FieldName = 'vICMS'
      Size = 31
    end
    object cdsNotaFiscalvBCST: TStringField
      FieldName = 'vBCST'
      Size = 31
    end
    object cdsNotaFiscalvST: TStringField
      FieldName = 'vST'
      Size = 31
    end
    object cdsNotaFiscalvProd: TStringField
      FieldName = 'vProd'
      Size = 31
    end
    object cdsNotaFiscalvFrete: TStringField
      FieldName = 'vFrete'
      Size = 31
    end
    object cdsNotaFiscalvSeg: TStringField
      FieldName = 'vSeg'
      Size = 31
    end
    object cdsNotaFiscalICMSTot_vDesc: TStringField
      FieldName = 'ICMSTot_vDesc'
      Size = 31
    end
    object cdsNotaFiscalvII: TStringField
      FieldName = 'vII'
      Size = 31
    end
    object cdsNotaFiscalvIPI: TStringField
      FieldName = 'vIPI'
      Size = 31
    end
    object cdsNotaFiscalICMSTot_vPIS: TStringField
      FieldName = 'ICMSTot_vPIS'
      Size = 31
    end
    object cdsNotaFiscalICMSTot_vCOFINS: TStringField
      FieldName = 'ICMSTot_vCOFINS'
      Size = 31
    end
    object cdsNotaFiscalvOutro: TStringField
      FieldName = 'vOutro'
      Size = 31
    end
    object cdsNotaFiscalISSQNtot_vServ: TStringField
      FieldName = 'ISSQNtot_vServ'
      Size = 31
    end
    object cdsNotaFiscalISSQNtot_vBC: TStringField
      FieldName = 'ISSQNtot_vBC'
      Size = 31
    end
    object cdsNotaFiscalvISS: TStringField
      FieldName = 'vISS'
      Size = 31
    end
    object cdsNotaFiscalISSQNtot_vPIS: TStringField
      FieldName = 'ISSQNtot_vPIS'
      Size = 31
    end
    object cdsNotaFiscalISSQNtot_vCOFINS: TStringField
      FieldName = 'ISSQNtot_vCOFINS'
      Size = 31
    end
    object cdsNotaFiscalvRetPIS: TStringField
      FieldName = 'vRetPIS'
      Size = 31
    end
    object cdsNotaFiscalvRetCOFINS: TStringField
      FieldName = 'vRetCOFINS'
      Size = 31
    end
    object cdsNotaFiscalvRetCSLL: TStringField
      FieldName = 'vRetCSLL'
      Size = 31
    end
    object cdsNotaFiscalvBCIRRF: TStringField
      FieldName = 'vBCIRRF'
      Size = 31
    end
    object cdsNotaFiscalvIRRF: TStringField
      FieldName = 'vIRRF'
      Size = 31
    end
    object cdsNotaFiscalvBCRetPrev: TStringField
      FieldName = 'vBCRetPrev'
      Size = 31
    end
    object cdsNotaFiscalvRetPrev: TStringField
      FieldName = 'vRetPrev'
      Size = 31
    end
    object cdsNotaFiscalmodFrete: TStringField
      FieldName = 'modFrete'
      Size = 31
    end
    object cdsNotaFiscalCNPJ: TStringField
      FieldName = 'CNPJ'
      Size = 31
    end
    object cdsNotaFiscalCPF: TStringField
      FieldName = 'CPF'
      Size = 31
    end
    object cdsNotaFiscalxNome: TStringField
      FieldName = 'xNome'
      Size = 60
    end
    object cdsNotaFiscalIE: TStringField
      FieldName = 'IE'
      Size = 31
    end
    object cdsNotaFiscalxEnder: TStringField
      FieldName = 'xEnder'
      Size = 60
    end
    object cdsNotaFiscaltransporta_xMun: TStringField
      FieldName = 'transporta_xMun'
      Size = 60
    end
    object cdsNotaFiscaltransporta_UF: TStringField
      FieldName = 'transporta_UF'
      Size = 31
    end
    object cdsNotaFiscalretTransp_vServ: TStringField
      FieldName = 'retTransp_vServ'
      Size = 31
    end
    object cdsNotaFiscalvBCRet: TStringField
      FieldName = 'vBCRet'
      Size = 31
    end
    object cdsNotaFiscalpICMSRet: TStringField
      FieldName = 'pICMSRet'
      Size = 31
    end
    object cdsNotaFiscalvICMSRet: TStringField
      FieldName = 'vICMSRet'
      Size = 31
    end
    object cdsNotaFiscalCFOP: TStringField
      FieldName = 'CFOP'
      Size = 31
    end
    object cdsNotaFiscalcMunFG2: TStringField
      FieldName = 'cMunFG2'
      Size = 31
    end
    object cdsNotaFiscalveicTransp_placa: TStringField
      FieldName = 'veicTransp_placa'
      Size = 8
    end
    object cdsNotaFiscalveicTransp_UF: TStringField
      FieldName = 'veicTransp_UF'
      Size = 31
    end
    object cdsNotaFiscalveicTransp_RNTC: TStringField
      FieldName = 'veicTransp_RNTC'
    end
    object cdsNotaFiscalreboque_placa: TStringField
      FieldName = 'reboque_placa'
      Size = 8
    end
    object cdsNotaFiscalreboque_UF: TStringField
      FieldName = 'reboque_UF'
      Size = 31
    end
    object cdsNotaFiscalreboque_RNTC: TStringField
      FieldName = 'reboque_RNTC'
    end
    object cdsNotaFiscalvagao: TStringField
      FieldName = 'vagao'
    end
    object cdsNotaFiscalbalsa: TStringField
      FieldName = 'balsa'
    end
    object cdsNotaFiscalnFat: TStringField
      FieldName = 'nFat'
      Size = 60
    end
    object cdsNotaFiscalvOrig: TStringField
      FieldName = 'vOrig'
      Size = 31
    end
    object cdsNotaFiscalfat_vDesc: TStringField
      FieldName = 'fat_vDesc'
      Size = 31
    end
    object cdsNotaFiscalvLiq: TStringField
      FieldName = 'vLiq'
      Size = 31
    end
    object cdsNotaFiscalinfAdFisco: TStringField
      FieldName = 'infAdFisco'
      Size = 2000
    end
    object cdsNotaFiscalobsCont_xCampo: TStringField
      FieldName = 'obsCont_xCampo'
      Required = True
    end
    object cdsNotaFiscalobsCont_xTexto: TStringField
      FieldName = 'obsCont_xTexto'
      Size = 60
    end
    object cdsNotaFiscalobsFisco_xCampo: TStringField
      FieldName = 'obsFisco_xCampo'
      Required = True
    end
    object cdsNotaFiscalobsFisco_xTexto: TStringField
      FieldName = 'obsFisco_xTexto'
      Size = 60
    end
    object cdsNotaFiscalUFEmbarq: TStringField
      FieldName = 'UFEmbarq'
      Size = 31
    end
    object cdsNotaFiscalxLocEmbarq: TStringField
      FieldName = 'xLocEmbarq'
      Size = 60
    end
    object cdsNotaFiscalxNEmp: TStringField
      FieldName = 'xNEmp'
      Size = 17
    end
    object cdsNotaFiscalxPed: TStringField
      FieldName = 'xPed'
      Size = 15
    end
    object cdsNotaFiscalxCont: TStringField
      FieldName = 'xCont'
      Size = 60
    end
    object cdsNotaFiscalsafra: TStringField
      FieldName = 'safra'
      Size = 9
    end
    object cdsNotaFiscalref: TStringField
      FieldName = 'ref'
      Size = 31
    end
    object cdsNotaFiscaldia: TStringField
      FieldName = 'dia'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalqtde: TStringField
      FieldName = 'qtde'
      Size = 31
    end
    object cdsNotaFiscalqTotMes: TStringField
      FieldName = 'qTotMes'
      Size = 31
    end
    object cdsNotaFiscalqTotAnt: TStringField
      FieldName = 'qTotAnt'
      Size = 31
    end
    object cdsNotaFiscalqTotGer: TStringField
      FieldName = 'qTotGer'
      Size = 31
    end
    object cdsNotaFiscalxDed: TStringField
      FieldName = 'xDed'
      Size = 60
    end
    object cdsNotaFiscalvDed: TStringField
      FieldName = 'vDed'
      Size = 31
    end
    object cdsNotaFiscalvFor: TStringField
      FieldName = 'vFor'
      Size = 31
    end
    object cdsNotaFiscalvTodDed: TStringField
      FieldName = 'vTodDed'
      Size = 31
    end
    object cdsNotaFiscalvLiqFor: TStringField
      FieldName = 'vLiqFor'
      Size = 31
    end
    object cdsNotaFiscalSignature_Id: TStringField
      FieldName = 'Signature_Id'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalSignedInfo_Id: TStringField
      FieldName = 'SignedInfo_Id'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalAlgorithm1: TStringField
      FieldName = 'Algorithm1'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalSignatureMethod_Algorithm: TStringField
      FieldName = 'SignatureMethod_Algorithm'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalId: TStringField
      FieldName = 'Id'
      Required = True
      Size = 47
    end
    object cdsNotaFiscalURI: TStringField
      FieldName = 'URI'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalType: TStringField
      FieldName = 'Type'
      Size = 31
    end
    object cdsNotaFiscalAlgorithm2: TStringField
      FieldName = 'Algorithm2'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalXPath: TStringField
      FieldName = 'XPath'
      Size = 31
    end
    object cdsNotaFiscalAlgorithm3: TStringField
      FieldName = 'Algorithm3'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalDigestValue: TStringField
      FieldName = 'DigestValue'
      Size = 31
    end
    object cdsNotaFiscalSignatureValue_Id: TStringField
      FieldName = 'SignatureValue_Id'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalKeyInfo_Id: TStringField
      FieldName = 'KeyInfo_Id'
      Required = True
      Size = 31
    end
    object cdsNotaFiscalX509Certificate: TStringField
      FieldName = 'X509Certificate'
      Size = 31
    end
    object cdsNotaFiscalNFref: TDataSetField
      FieldName = 'NFref'
      UnNamed = True
    end
    object cdsNotaFiscaldet: TDataSetField
      FieldName = 'det'
      UnNamed = True
    end
    object cdsNotaFiscalvol: TDataSetField
      FieldName = 'vol'
      UnNamed = True
    end
    object cdsNotaFiscaldup: TDataSetField
      FieldName = 'dup'
      UnNamed = True
    end
    object cdsNotaFiscalprocRef: TDataSetField
      FieldName = 'procRef'
      UnNamed = True
    end
    object cdsNotaFiscalinfCpl: TStringField
      FieldName = 'infCpl'
      Size = 5000
    end
    object cdsNotaFiscalenderDest_CEP: TStringField
      FieldName = 'enderDest_CEP'
      Size = 31
    end
    object cdsNotaFiscalvNF: TStringField
      FieldName = 'vNF'
      Size = 31
    end
  end
  object XTPNFE: TXMLTransformProvider
    TransformRead.TransformationFile = '.\xsd\ToDp200.xtr'
    TransformWrite.TransformationFile = '.\xsd\ToDp200.xtr'
    Left = 12
    Top = 380
  end
  object cdsItensDaNota: TClientDataSet
    Aggregates = <>
    DataSetField = cdsNotaFiscaldet
    FieldDefs = <
      item
        Name = 'nItem'
        Attributes = [faRequired, faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 60
      end
      item
        Name = 'cEAN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'xProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 120
      end
      item
        Name = 'NCM'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'EXTIPI'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'CFOP'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'uCom'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 6
      end
      item
        Name = 'qCom'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vUnCom'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cEANTrib'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'uTrib'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 6
      end
      item
        Name = 'qTrib'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vUnTrib'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vFrete'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vSeg'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vDesc'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vOutro'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'indTot'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'xPed'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 15
      end
      item
        Name = 'nItemPed'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'tpOp'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'chassi'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cCor'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 4
      end
      item
        Name = 'xCor'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 40
      end
      item
        Name = 'pot'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 4
      end
      item
        Name = 'cilin'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 4
      end
      item
        Name = 'pesoL'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 9
      end
      item
        Name = 'pesoB'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 9
      end
      item
        Name = 'nSerie'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 9
      end
      item
        Name = 'tpComb'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 2
      end
      item
        Name = 'nMotor'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 21
      end
      item
        Name = 'CMT'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 9
      end
      item
        Name = 'dist'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 4
      end
      item
        Name = 'anoMod'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'anoFab'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'tpPint'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'tpVeic'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'espVeic'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'VIN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'condVeic'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cMod'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cCorDENATRAN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 2
      end
      item
        Name = 'lota'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 3
      end
      item
        Name = 'tpRest'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cProdANP'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'CODIF'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'qTemp'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'UFCons'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'CIDE_qBCProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'CIDE_vAliqProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vCIDE'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS00_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS00_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS00_modBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS00_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS00_pICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS00_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_modBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_pICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_modBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_pMVAST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_pRedBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_vBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_pICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS10_vICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS20_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS20_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS20_modBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS20_pRedBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS20_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS20_pICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS20_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS30_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS30_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS30_modBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS30_pMVAST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS30_pRedBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS30_vBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS30_pICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS30_vICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS40_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS40_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS40_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'motDesICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS51_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS51_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS51_modBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS51_pRedBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS51_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS51_pICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS51_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS60_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS60_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS60_vBCSTRet'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS60_vICMSSTRet'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_modBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_pRedBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_pICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_modBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_pMVAST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_pRedBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_vBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_pICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS70_vICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_modBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_pRedBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_pICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_modBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_pMVAST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_pRedBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_vBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_pICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMS90_vICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_modBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_pRedBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_pICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_modBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_pMVAST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_pRedBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_vBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_pICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSPart_vICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'pBCOp'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'UFST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSST_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSST_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSST_vBCSTRet'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSST_vICMSSTRet'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vBCSTDest'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vICMSSTDest'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN101_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN101_CSOSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN101_pCredSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN101_vCredICMSSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN102_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN102_CSOSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_CSOSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_modBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_pMVAST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_pRedBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_vBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_pICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_vICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_pCredSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN201_vCredICMSSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN202_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN202_CSOSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN202_modBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN202_pMVAST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN202_pRedBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN202_vBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN202_pICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN202_vICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN500_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN500_CSOSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN500_vBCSTRet'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN500_vICMSSTRet'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_orig'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_CSOSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_modBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_pRedBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_pICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_vICMS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_modBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_pMVAST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_pRedBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_vBCST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_pICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_vICMSST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_pCredSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ICMSSN900_vCredICMSSN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'clEnq'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 5
      end
      item
        Name = 'CNPJProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cSelo'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 60
      end
      item
        Name = 'qSelo'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cEnq'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 3
      end
      item
        Name = 'IPITrib_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'IPITrib_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'pIPI'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'qUnid'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vUnid'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vIPI'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'IPINT_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'II_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vDespAdu'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vII'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vIOF'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'ISSQN_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vAliq'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vISSQN'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cMunFG'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cListServ'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'cSitTrib'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISAliq_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISAliq_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISAliq_pPIS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISAliq_vPIS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISQtde_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISQtde_qBCProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISQtde_vAliqProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISQtde_vPIS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISNT_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISOutr_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISOutr_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISOutr_pPIS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISOutr_qBCProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISOutr_vAliqProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISOutr_vPIS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISST_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'pPIS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISST_qBCProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'PISST_vAliqProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vPIS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSAliq_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSAliq_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSAliq_pCOFINS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSAliq_vCOFINS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSQtde_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSQtde_qBCProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSQtde_vAliqProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSQtde_vCOFINS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSNT_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSOutr_CST'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSOutr_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSOutr_pCOFINS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSOutr_qBCProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSOutr_vAliqProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSOutr_vCOFINS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSST_vBC'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'pCOFINS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSST_qBCProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'COFINSST_vAliqProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'vCOFINS'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 31
      end
      item
        Name = 'infAdProd'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 500
      end
      item
        Name = 'DI'
        Attributes = [faUnNamed]
        DataType = ftDataSet
      end
      item
        Name = 'med'
        Attributes = [faUnNamed]
        DataType = ftDataSet
      end
      item
        Name = 'arma'
        Attributes = [faUnNamed]
        DataType = ftDataSet
      end>
    IndexDefs = <>
    Params = <>
    StoreDefs = True
    Left = 12
    Top = 271
    object cdsItensDaNotanItem: TStringField
      FieldName = 'nItem'
      Required = True
      Size = 31
    end
    object cdsItensDaNotacProd: TStringField
      FieldName = 'cProd'
      Size = 60
    end
    object cdsItensDaNotacEAN: TStringField
      FieldName = 'cEAN'
      Size = 31
    end
    object cdsItensDaNotaxProd: TStringField
      FieldName = 'xProd'
      Size = 120
    end
    object cdsItensDaNotaNCM: TStringField
      FieldName = 'NCM'
      Size = 31
    end
    object cdsItensDaNotaEXTIPI: TStringField
      FieldName = 'EXTIPI'
      Size = 31
    end
    object cdsItensDaNotaCFOP: TStringField
      FieldName = 'CFOP'
      Size = 31
    end
    object cdsItensDaNotauCom: TStringField
      FieldName = 'uCom'
      Size = 6
    end
    object cdsItensDaNotaqCom: TStringField
      FieldName = 'qCom'
      Size = 31
    end
    object cdsItensDaNotavUnCom: TStringField
      FieldName = 'vUnCom'
      Size = 31
    end
    object cdsItensDaNotavProd: TStringField
      FieldName = 'vProd'
      Size = 31
    end
    object cdsItensDaNotacEANTrib: TStringField
      FieldName = 'cEANTrib'
      Size = 31
    end
    object cdsItensDaNotauTrib: TStringField
      FieldName = 'uTrib'
      Size = 6
    end
    object cdsItensDaNotaqTrib: TStringField
      FieldName = 'qTrib'
      Size = 31
    end
    object cdsItensDaNotavUnTrib: TStringField
      FieldName = 'vUnTrib'
      Size = 31
    end
    object cdsItensDaNotavFrete: TStringField
      FieldName = 'vFrete'
      Size = 31
    end
    object cdsItensDaNotavSeg: TStringField
      FieldName = 'vSeg'
      Size = 31
    end
    object cdsItensDaNotavDesc: TStringField
      FieldName = 'vDesc'
      Size = 31
    end
    object cdsItensDaNotavOutro: TStringField
      FieldName = 'vOutro'
      Size = 31
    end
    object cdsItensDaNotaindTot: TStringField
      FieldName = 'indTot'
      Size = 31
    end
    object cdsItensDaNotaxPed: TStringField
      FieldName = 'xPed'
      Size = 15
    end
    object cdsItensDaNotanItemPed: TStringField
      FieldName = 'nItemPed'
      Size = 31
    end
    object cdsItensDaNotatpOp: TStringField
      FieldName = 'tpOp'
      Size = 31
    end
    object cdsItensDaNotachassi: TStringField
      FieldName = 'chassi'
      Size = 31
    end
    object cdsItensDaNotacCor: TStringField
      FieldName = 'cCor'
      Size = 4
    end
    object cdsItensDaNotaxCor: TStringField
      FieldName = 'xCor'
      Size = 40
    end
    object cdsItensDaNotapot: TStringField
      FieldName = 'pot'
      Size = 4
    end
    object cdsItensDaNotacilin: TStringField
      FieldName = 'cilin'
      Size = 4
    end
    object cdsItensDaNotapesoL: TStringField
      FieldName = 'pesoL'
      Size = 9
    end
    object cdsItensDaNotapesoB: TStringField
      FieldName = 'pesoB'
      Size = 9
    end
    object cdsItensDaNotanSerie: TStringField
      FieldName = 'nSerie'
      Size = 9
    end
    object cdsItensDaNotatpComb: TStringField
      FieldName = 'tpComb'
      Size = 2
    end
    object cdsItensDaNotanMotor: TStringField
      FieldName = 'nMotor'
      Size = 21
    end
    object cdsItensDaNotaCMT: TStringField
      FieldName = 'CMT'
      Size = 9
    end
    object cdsItensDaNotadist: TStringField
      FieldName = 'dist'
      Size = 4
    end
    object cdsItensDaNotaanoMod: TStringField
      FieldName = 'anoMod'
      Size = 31
    end
    object cdsItensDaNotaanoFab: TStringField
      FieldName = 'anoFab'
      Size = 31
    end
    object cdsItensDaNotatpPint: TStringField
      FieldName = 'tpPint'
      Size = 31
    end
    object cdsItensDaNotatpVeic: TStringField
      FieldName = 'tpVeic'
      Size = 31
    end
    object cdsItensDaNotaespVeic: TStringField
      FieldName = 'espVeic'
      Size = 31
    end
    object cdsItensDaNotaVIN: TStringField
      FieldName = 'VIN'
      Size = 31
    end
    object cdsItensDaNotacondVeic: TStringField
      FieldName = 'condVeic'
      Size = 31
    end
    object cdsItensDaNotacMod: TStringField
      FieldName = 'cMod'
      Size = 31
    end
    object cdsItensDaNotacCorDENATRAN: TStringField
      FieldName = 'cCorDENATRAN'
      Size = 2
    end
    object cdsItensDaNotalota: TStringField
      FieldName = 'lota'
      Size = 3
    end
    object cdsItensDaNotatpRest: TStringField
      FieldName = 'tpRest'
      Size = 31
    end
    object cdsItensDaNotacProdANP: TStringField
      FieldName = 'cProdANP'
      Size = 31
    end
    object cdsItensDaNotaCODIF: TStringField
      FieldName = 'CODIF'
      Size = 31
    end
    object cdsItensDaNotaqTemp: TStringField
      FieldName = 'qTemp'
      Size = 31
    end
    object cdsItensDaNotaUFCons: TStringField
      FieldName = 'UFCons'
      Size = 31
    end
    object cdsItensDaNotaCIDE_qBCProd: TStringField
      FieldName = 'CIDE_qBCProd'
      Size = 31
    end
    object cdsItensDaNotaCIDE_vAliqProd: TStringField
      FieldName = 'CIDE_vAliqProd'
      Size = 31
    end
    object cdsItensDaNotavCIDE: TStringField
      FieldName = 'vCIDE'
      Size = 31
    end
    object cdsItensDaNotaICMS00_orig: TStringField
      FieldName = 'ICMS00_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS00_CST: TStringField
      FieldName = 'ICMS00_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS00_modBC: TStringField
      FieldName = 'ICMS00_modBC'
      Size = 31
    end
    object cdsItensDaNotaICMS00_vBC: TStringField
      FieldName = 'ICMS00_vBC'
      Size = 31
    end
    object cdsItensDaNotaICMS00_pICMS: TStringField
      FieldName = 'ICMS00_pICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS00_vICMS: TStringField
      FieldName = 'ICMS00_vICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS10_orig: TStringField
      FieldName = 'ICMS10_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS10_CST: TStringField
      FieldName = 'ICMS10_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS10_modBC: TStringField
      FieldName = 'ICMS10_modBC'
      Size = 31
    end
    object cdsItensDaNotaICMS10_vBC: TStringField
      FieldName = 'ICMS10_vBC'
      Size = 31
    end
    object cdsItensDaNotaICMS10_pICMS: TStringField
      FieldName = 'ICMS10_pICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS10_vICMS: TStringField
      FieldName = 'ICMS10_vICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS10_modBCST: TStringField
      FieldName = 'ICMS10_modBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS10_pMVAST: TStringField
      FieldName = 'ICMS10_pMVAST'
      Size = 31
    end
    object cdsItensDaNotaICMS10_pRedBCST: TStringField
      FieldName = 'ICMS10_pRedBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS10_vBCST: TStringField
      FieldName = 'ICMS10_vBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS10_pICMSST: TStringField
      FieldName = 'ICMS10_pICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMS10_vICMSST: TStringField
      FieldName = 'ICMS10_vICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMS20_orig: TStringField
      FieldName = 'ICMS20_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS20_CST: TStringField
      FieldName = 'ICMS20_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS20_modBC: TStringField
      FieldName = 'ICMS20_modBC'
      Size = 31
    end
    object cdsItensDaNotaICMS20_pRedBC: TStringField
      FieldName = 'ICMS20_pRedBC'
      Size = 31
    end
    object cdsItensDaNotaICMS20_vBC: TStringField
      FieldName = 'ICMS20_vBC'
      Size = 31
    end
    object cdsItensDaNotaICMS20_pICMS: TStringField
      FieldName = 'ICMS20_pICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS20_vICMS: TStringField
      FieldName = 'ICMS20_vICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS30_orig: TStringField
      FieldName = 'ICMS30_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS30_CST: TStringField
      FieldName = 'ICMS30_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS30_modBCST: TStringField
      FieldName = 'ICMS30_modBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS30_pMVAST: TStringField
      FieldName = 'ICMS30_pMVAST'
      Size = 31
    end
    object cdsItensDaNotaICMS30_pRedBCST: TStringField
      FieldName = 'ICMS30_pRedBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS30_vBCST: TStringField
      FieldName = 'ICMS30_vBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS30_pICMSST: TStringField
      FieldName = 'ICMS30_pICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMS30_vICMSST: TStringField
      FieldName = 'ICMS30_vICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMS40_orig: TStringField
      FieldName = 'ICMS40_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS40_CST: TStringField
      FieldName = 'ICMS40_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS40_vICMS: TStringField
      FieldName = 'ICMS40_vICMS'
      Size = 31
    end
    object cdsItensDaNotamotDesICMS: TStringField
      FieldName = 'motDesICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS51_orig: TStringField
      FieldName = 'ICMS51_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS51_CST: TStringField
      FieldName = 'ICMS51_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS51_modBC: TStringField
      FieldName = 'ICMS51_modBC'
      Size = 31
    end
    object cdsItensDaNotaICMS51_pRedBC: TStringField
      FieldName = 'ICMS51_pRedBC'
      Size = 31
    end
    object cdsItensDaNotaICMS51_vBC: TStringField
      FieldName = 'ICMS51_vBC'
      Size = 31
    end
    object cdsItensDaNotaICMS51_pICMS: TStringField
      FieldName = 'ICMS51_pICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS51_vICMS: TStringField
      FieldName = 'ICMS51_vICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS60_orig: TStringField
      FieldName = 'ICMS60_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS60_CST: TStringField
      FieldName = 'ICMS60_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS60_vBCSTRet: TStringField
      FieldName = 'ICMS60_vBCSTRet'
      Size = 31
    end
    object cdsItensDaNotaICMS60_vICMSSTRet: TStringField
      FieldName = 'ICMS60_vICMSSTRet'
      Size = 31
    end
    object cdsItensDaNotaICMS70_orig: TStringField
      FieldName = 'ICMS70_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS70_CST: TStringField
      FieldName = 'ICMS70_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS70_modBC: TStringField
      FieldName = 'ICMS70_modBC'
      Size = 31
    end
    object cdsItensDaNotaICMS70_pRedBC: TStringField
      FieldName = 'ICMS70_pRedBC'
      Size = 31
    end
    object cdsItensDaNotaICMS70_vBC: TStringField
      FieldName = 'ICMS70_vBC'
      Size = 31
    end
    object cdsItensDaNotaICMS70_pICMS: TStringField
      FieldName = 'ICMS70_pICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS70_vICMS: TStringField
      FieldName = 'ICMS70_vICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS70_modBCST: TStringField
      FieldName = 'ICMS70_modBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS70_pMVAST: TStringField
      FieldName = 'ICMS70_pMVAST'
      Size = 31
    end
    object cdsItensDaNotaICMS70_pRedBCST: TStringField
      FieldName = 'ICMS70_pRedBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS70_vBCST: TStringField
      FieldName = 'ICMS70_vBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS70_pICMSST: TStringField
      FieldName = 'ICMS70_pICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMS70_vICMSST: TStringField
      FieldName = 'ICMS70_vICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMS90_orig: TStringField
      FieldName = 'ICMS90_orig'
      Size = 31
    end
    object cdsItensDaNotaICMS90_CST: TStringField
      FieldName = 'ICMS90_CST'
      Size = 31
    end
    object cdsItensDaNotaICMS90_modBC: TStringField
      FieldName = 'ICMS90_modBC'
      Size = 31
    end
    object cdsItensDaNotaICMS90_vBC: TStringField
      FieldName = 'ICMS90_vBC'
      Size = 31
    end
    object cdsItensDaNotaICMS90_pRedBC: TStringField
      FieldName = 'ICMS90_pRedBC'
      Size = 31
    end
    object cdsItensDaNotaICMS90_pICMS: TStringField
      FieldName = 'ICMS90_pICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS90_vICMS: TStringField
      FieldName = 'ICMS90_vICMS'
      Size = 31
    end
    object cdsItensDaNotaICMS90_modBCST: TStringField
      FieldName = 'ICMS90_modBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS90_pMVAST: TStringField
      FieldName = 'ICMS90_pMVAST'
      Size = 31
    end
    object cdsItensDaNotaICMS90_pRedBCST: TStringField
      FieldName = 'ICMS90_pRedBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS90_vBCST: TStringField
      FieldName = 'ICMS90_vBCST'
      Size = 31
    end
    object cdsItensDaNotaICMS90_pICMSST: TStringField
      FieldName = 'ICMS90_pICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMS90_vICMSST: TStringField
      FieldName = 'ICMS90_vICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_orig: TStringField
      FieldName = 'ICMSPart_orig'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_CST: TStringField
      FieldName = 'ICMSPart_CST'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_modBC: TStringField
      FieldName = 'ICMSPart_modBC'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_vBC: TStringField
      FieldName = 'ICMSPart_vBC'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_pRedBC: TStringField
      FieldName = 'ICMSPart_pRedBC'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_pICMS: TStringField
      FieldName = 'ICMSPart_pICMS'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_vICMS: TStringField
      FieldName = 'ICMSPart_vICMS'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_modBCST: TStringField
      FieldName = 'ICMSPart_modBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_pMVAST: TStringField
      FieldName = 'ICMSPart_pMVAST'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_pRedBCST: TStringField
      FieldName = 'ICMSPart_pRedBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_vBCST: TStringField
      FieldName = 'ICMSPart_vBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_pICMSST: TStringField
      FieldName = 'ICMSPart_pICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMSPart_vICMSST: TStringField
      FieldName = 'ICMSPart_vICMSST'
      Size = 31
    end
    object cdsItensDaNotapBCOp: TStringField
      FieldName = 'pBCOp'
      Size = 31
    end
    object cdsItensDaNotaUFST: TStringField
      FieldName = 'UFST'
      Size = 31
    end
    object cdsItensDaNotaICMSST_orig: TStringField
      FieldName = 'ICMSST_orig'
      Size = 31
    end
    object cdsItensDaNotaICMSST_CST: TStringField
      FieldName = 'ICMSST_CST'
      Size = 31
    end
    object cdsItensDaNotaICMSST_vBCSTRet: TStringField
      FieldName = 'ICMSST_vBCSTRet'
      Size = 31
    end
    object cdsItensDaNotaICMSST_vICMSSTRet: TStringField
      FieldName = 'ICMSST_vICMSSTRet'
      Size = 31
    end
    object cdsItensDaNotavBCSTDest: TStringField
      FieldName = 'vBCSTDest'
      Size = 31
    end
    object cdsItensDaNotavICMSSTDest: TStringField
      FieldName = 'vICMSSTDest'
      Size = 31
    end
    object cdsItensDaNotaICMSSN101_orig: TStringField
      FieldName = 'ICMSSN101_orig'
      Size = 31
    end
    object cdsItensDaNotaICMSSN101_CSOSN: TStringField
      FieldName = 'ICMSSN101_CSOSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN101_pCredSN: TStringField
      FieldName = 'ICMSSN101_pCredSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN101_vCredICMSSN: TStringField
      FieldName = 'ICMSSN101_vCredICMSSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN102_orig: TStringField
      FieldName = 'ICMSSN102_orig'
      Size = 31
    end
    object cdsItensDaNotaICMSSN102_CSOSN: TStringField
      FieldName = 'ICMSSN102_CSOSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_orig: TStringField
      FieldName = 'ICMSSN201_orig'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_CSOSN: TStringField
      FieldName = 'ICMSSN201_CSOSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_modBCST: TStringField
      FieldName = 'ICMSSN201_modBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_pMVAST: TStringField
      FieldName = 'ICMSSN201_pMVAST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_pRedBCST: TStringField
      FieldName = 'ICMSSN201_pRedBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_vBCST: TStringField
      FieldName = 'ICMSSN201_vBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_pICMSST: TStringField
      FieldName = 'ICMSSN201_pICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_vICMSST: TStringField
      FieldName = 'ICMSSN201_vICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_pCredSN: TStringField
      FieldName = 'ICMSSN201_pCredSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN201_vCredICMSSN: TStringField
      FieldName = 'ICMSSN201_vCredICMSSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN202_orig: TStringField
      FieldName = 'ICMSSN202_orig'
      Size = 31
    end
    object cdsItensDaNotaICMSSN202_CSOSN: TStringField
      FieldName = 'ICMSSN202_CSOSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN202_modBCST: TStringField
      FieldName = 'ICMSSN202_modBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN202_pMVAST: TStringField
      FieldName = 'ICMSSN202_pMVAST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN202_pRedBCST: TStringField
      FieldName = 'ICMSSN202_pRedBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN202_vBCST: TStringField
      FieldName = 'ICMSSN202_vBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN202_pICMSST: TStringField
      FieldName = 'ICMSSN202_pICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN202_vICMSST: TStringField
      FieldName = 'ICMSSN202_vICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN500_orig: TStringField
      FieldName = 'ICMSSN500_orig'
      Size = 31
    end
    object cdsItensDaNotaICMSSN500_CSOSN: TStringField
      FieldName = 'ICMSSN500_CSOSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN500_vBCSTRet: TStringField
      FieldName = 'ICMSSN500_vBCSTRet'
      Size = 31
    end
    object cdsItensDaNotaICMSSN500_vICMSSTRet: TStringField
      FieldName = 'ICMSSN500_vICMSSTRet'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_orig: TStringField
      FieldName = 'ICMSSN900_orig'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_CSOSN: TStringField
      FieldName = 'ICMSSN900_CSOSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_modBC: TStringField
      FieldName = 'ICMSSN900_modBC'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_vBC: TStringField
      FieldName = 'ICMSSN900_vBC'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_pRedBC: TStringField
      FieldName = 'ICMSSN900_pRedBC'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_pICMS: TStringField
      FieldName = 'ICMSSN900_pICMS'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_vICMS: TStringField
      FieldName = 'ICMSSN900_vICMS'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_modBCST: TStringField
      FieldName = 'ICMSSN900_modBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_pMVAST: TStringField
      FieldName = 'ICMSSN900_pMVAST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_pRedBCST: TStringField
      FieldName = 'ICMSSN900_pRedBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_vBCST: TStringField
      FieldName = 'ICMSSN900_vBCST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_pICMSST: TStringField
      FieldName = 'ICMSSN900_pICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_vICMSST: TStringField
      FieldName = 'ICMSSN900_vICMSST'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_pCredSN: TStringField
      FieldName = 'ICMSSN900_pCredSN'
      Size = 31
    end
    object cdsItensDaNotaICMSSN900_vCredICMSSN: TStringField
      FieldName = 'ICMSSN900_vCredICMSSN'
      Size = 31
    end
    object cdsItensDaNotaclEnq: TStringField
      FieldName = 'clEnq'
      Size = 5
    end
    object cdsItensDaNotaCNPJProd: TStringField
      FieldName = 'CNPJProd'
      Size = 31
    end
    object cdsItensDaNotacSelo: TStringField
      FieldName = 'cSelo'
      Size = 60
    end
    object cdsItensDaNotaqSelo: TStringField
      FieldName = 'qSelo'
      Size = 31
    end
    object cdsItensDaNotacEnq: TStringField
      FieldName = 'cEnq'
      Size = 3
    end
    object cdsItensDaNotaIPITrib_CST: TStringField
      FieldName = 'IPITrib_CST'
      Size = 31
    end
    object cdsItensDaNotaIPITrib_vBC: TStringField
      FieldName = 'IPITrib_vBC'
      Size = 31
    end
    object cdsItensDaNotapIPI: TStringField
      FieldName = 'pIPI'
      Size = 31
    end
    object cdsItensDaNotaqUnid: TStringField
      FieldName = 'qUnid'
      Size = 31
    end
    object cdsItensDaNotavUnid: TStringField
      FieldName = 'vUnid'
      Size = 31
    end
    object cdsItensDaNotavIPI: TStringField
      FieldName = 'vIPI'
      Size = 31
    end
    object cdsItensDaNotaIPINT_CST: TStringField
      FieldName = 'IPINT_CST'
      Size = 31
    end
    object cdsItensDaNotaII_vBC: TStringField
      FieldName = 'II_vBC'
      Size = 31
    end
    object cdsItensDaNotavDespAdu: TStringField
      FieldName = 'vDespAdu'
      Size = 31
    end
    object cdsItensDaNotavII: TStringField
      FieldName = 'vII'
      Size = 31
    end
    object cdsItensDaNotavIOF: TStringField
      FieldName = 'vIOF'
      Size = 31
    end
    object cdsItensDaNotaISSQN_vBC: TStringField
      FieldName = 'ISSQN_vBC'
      Size = 31
    end
    object cdsItensDaNotavAliq: TStringField
      FieldName = 'vAliq'
      Size = 31
    end
    object cdsItensDaNotavISSQN: TStringField
      FieldName = 'vISSQN'
      Size = 31
    end
    object cdsItensDaNotacMunFG: TStringField
      FieldName = 'cMunFG'
      Size = 31
    end
    object cdsItensDaNotacListServ: TStringField
      FieldName = 'cListServ'
      Size = 31
    end
    object cdsItensDaNotacSitTrib: TStringField
      FieldName = 'cSitTrib'
      Size = 31
    end
    object cdsItensDaNotaPISAliq_CST: TStringField
      FieldName = 'PISAliq_CST'
      Size = 31
    end
    object cdsItensDaNotaPISAliq_vBC: TStringField
      FieldName = 'PISAliq_vBC'
      Size = 31
    end
    object cdsItensDaNotaPISAliq_pPIS: TStringField
      FieldName = 'PISAliq_pPIS'
      Size = 31
    end
    object cdsItensDaNotaPISAliq_vPIS: TStringField
      FieldName = 'PISAliq_vPIS'
      Size = 31
    end
    object cdsItensDaNotaPISQtde_CST: TStringField
      FieldName = 'PISQtde_CST'
      Size = 31
    end
    object cdsItensDaNotaPISQtde_qBCProd: TStringField
      FieldName = 'PISQtde_qBCProd'
      Size = 31
    end
    object cdsItensDaNotaPISQtde_vAliqProd: TStringField
      FieldName = 'PISQtde_vAliqProd'
      Size = 31
    end
    object cdsItensDaNotaPISQtde_vPIS: TStringField
      FieldName = 'PISQtde_vPIS'
      Size = 31
    end
    object cdsItensDaNotaPISNT_CST: TStringField
      FieldName = 'PISNT_CST'
      Size = 31
    end
    object cdsItensDaNotaPISOutr_CST: TStringField
      FieldName = 'PISOutr_CST'
      Size = 31
    end
    object cdsItensDaNotaPISOutr_vBC: TStringField
      FieldName = 'PISOutr_vBC'
      Size = 31
    end
    object cdsItensDaNotaPISOutr_pPIS: TStringField
      FieldName = 'PISOutr_pPIS'
      Size = 31
    end
    object cdsItensDaNotaPISOutr_qBCProd: TStringField
      FieldName = 'PISOutr_qBCProd'
      Size = 31
    end
    object cdsItensDaNotaPISOutr_vAliqProd: TStringField
      FieldName = 'PISOutr_vAliqProd'
      Size = 31
    end
    object cdsItensDaNotaPISOutr_vPIS: TStringField
      FieldName = 'PISOutr_vPIS'
      Size = 31
    end
    object cdsItensDaNotaPISST_vBC: TStringField
      FieldName = 'PISST_vBC'
      Size = 31
    end
    object cdsItensDaNotapPIS: TStringField
      FieldName = 'pPIS'
      Size = 31
    end
    object cdsItensDaNotaPISST_qBCProd: TStringField
      FieldName = 'PISST_qBCProd'
      Size = 31
    end
    object cdsItensDaNotaPISST_vAliqProd: TStringField
      FieldName = 'PISST_vAliqProd'
      Size = 31
    end
    object cdsItensDaNotavPIS: TStringField
      FieldName = 'vPIS'
      Size = 31
    end
    object cdsItensDaNotaCOFINSAliq_CST: TStringField
      FieldName = 'COFINSAliq_CST'
      Size = 31
    end
    object cdsItensDaNotaCOFINSAliq_vBC: TStringField
      FieldName = 'COFINSAliq_vBC'
      Size = 31
    end
    object cdsItensDaNotaCOFINSAliq_pCOFINS: TStringField
      FieldName = 'COFINSAliq_pCOFINS'
      Size = 31
    end
    object cdsItensDaNotaCOFINSAliq_vCOFINS: TStringField
      FieldName = 'COFINSAliq_vCOFINS'
      Size = 31
    end
    object cdsItensDaNotaCOFINSQtde_CST: TStringField
      FieldName = 'COFINSQtde_CST'
      Size = 31
    end
    object cdsItensDaNotaCOFINSQtde_qBCProd: TStringField
      FieldName = 'COFINSQtde_qBCProd'
      Size = 31
    end
    object cdsItensDaNotaCOFINSQtde_vAliqProd: TStringField
      FieldName = 'COFINSQtde_vAliqProd'
      Size = 31
    end
    object cdsItensDaNotaCOFINSQtde_vCOFINS: TStringField
      FieldName = 'COFINSQtde_vCOFINS'
      Size = 31
    end
    object cdsItensDaNotaCOFINSNT_CST: TStringField
      FieldName = 'COFINSNT_CST'
      Size = 31
    end
    object cdsItensDaNotaCOFINSOutr_CST: TStringField
      FieldName = 'COFINSOutr_CST'
      Size = 31
    end
    object cdsItensDaNotaCOFINSOutr_vBC: TStringField
      FieldName = 'COFINSOutr_vBC'
      Size = 31
    end
    object cdsItensDaNotaCOFINSOutr_pCOFINS: TStringField
      FieldName = 'COFINSOutr_pCOFINS'
      Size = 31
    end
    object cdsItensDaNotaCOFINSOutr_qBCProd: TStringField
      FieldName = 'COFINSOutr_qBCProd'
      Size = 31
    end
    object cdsItensDaNotaCOFINSOutr_vAliqProd: TStringField
      FieldName = 'COFINSOutr_vAliqProd'
      Size = 31
    end
    object cdsItensDaNotaCOFINSOutr_vCOFINS: TStringField
      FieldName = 'COFINSOutr_vCOFINS'
      Size = 31
    end
    object cdsItensDaNotaCOFINSST_vBC: TStringField
      FieldName = 'COFINSST_vBC'
      Size = 31
    end
    object cdsItensDaNotapCOFINS: TStringField
      FieldName = 'pCOFINS'
      Size = 31
    end
    object cdsItensDaNotaCOFINSST_qBCProd: TStringField
      FieldName = 'COFINSST_qBCProd'
      Size = 31
    end
    object cdsItensDaNotaCOFINSST_vAliqProd: TStringField
      FieldName = 'COFINSST_vAliqProd'
      Size = 31
    end
    object cdsItensDaNotavCOFINS: TStringField
      FieldName = 'vCOFINS'
      Size = 31
    end
    object cdsItensDaNotainfAdProd: TStringField
      FieldName = 'infAdProd'
      Size = 500
    end
    object cdsItensDaNotaDI: TDataSetField
      FieldName = 'DI'
      UnNamed = True
    end
    object cdsItensDaNotamed: TDataSetField
      FieldName = 'med'
      UnNamed = True
    end
    object cdsItensDaNotaarma: TDataSetField
      FieldName = 'arma'
      UnNamed = True
    end
  end
  object cdsVolumesTransportados: TClientDataSet
    Aggregates = <>
    DataSetField = cdsNotaFiscalvol
    Params = <>
    Left = 14
    Top = 207
    object cdsVolumesTransportadosqVol: TStringField
      FieldName = 'qVol'
      Size = 31
    end
    object cdsVolumesTransportadosesp: TStringField
      FieldName = 'esp'
      Size = 60
    end
    object cdsVolumesTransportadosmarca: TStringField
      FieldName = 'marca'
      Size = 60
    end
    object cdsVolumesTransportadosnVol: TStringField
      FieldName = 'nVol'
      Size = 60
    end
    object cdsVolumesTransportadospesoL: TStringField
      FieldName = 'pesoL'
      Size = 9
    end
    object cdsVolumesTransportadospesoB: TStringField
      FieldName = 'pesoB'
      Size = 9
    end
    object cdsVolumesTransportadoslacres: TDataSetField
      FieldName = 'lacres'
      UnNamed = True
    end
  end
  object cdsLotesDoProduto: TClientDataSet
    Aggregates = <>
    Params = <>
    Left = 16
    Top = 143
    object cdsLotesDoProdutonLote: TStringField
      FieldName = 'nLote'
    end
    object cdsLotesDoProdutoqLote: TStringField
      FieldName = 'qLote'
      Size = 31
    end
    object cdsLotesDoProdutovPMC: TStringField
      FieldName = 'vPMC'
      Size = 31
    end
  end
  object dsFatIns: TDataSource
    DataSet = cdsItensDaNota
    Left = 12
    Top = 239
  end
  object XTPPROT: TXMLTransformProvider
    TransformRead.TransformationFile = '.\xsd\ToDpProtNFe.xtr'
    TransformWrite.TransformationFile = '.\xsd\ToDpProtNFe.xtr'
    Left = 16
    Top = 48
  end
  object cdsProtNFe: TClientDataSet
    Aggregates = <>
    FieldDefs = <
      item
        Name = 'versao'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 4
      end
      item
        Name = 'Id'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 47
      end
      item
        Name = 'tpAmb'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 1
      end
      item
        Name = 'verAplic'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 4
      end
      item
        Name = 'chNFe'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 44
      end
      item
        Name = 'dhRecbto'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 19
      end
      item
        Name = 'nProt'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 15
      end
      item
        Name = 'digVal'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 28
      end
      item
        Name = 'cStat'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 3
      end
      item
        Name = 'xMotivo'
        Attributes = [faUnNamed]
        DataType = ftString
        Size = 24
      end>
    IndexDefs = <>
    Params = <>
    ProviderName = 'XTPPROT'
    StoreDefs = True
    Left = 16
    Top = 80
    object cdsProtNFeversao: TStringField
      FieldName = 'versao'
      Size = 4
    end
    object cdsProtNFeId: TStringField
      FieldName = 'Id'
      Size = 47
    end
    object cdsProtNFetpAmb: TStringField
      FieldName = 'tpAmb'
      Size = 1
    end
    object cdsProtNFeverAplic: TStringField
      FieldName = 'verAplic'
      Size = 4
    end
    object cdsProtNFechNFe: TStringField
      FieldName = 'chNFe'
      Size = 44
    end
    object cdsProtNFedhRecbto: TStringField
      FieldName = 'dhRecbto'
      Size = 19
    end
    object cdsProtNFenProt: TStringField
      FieldName = 'nProt'
      Size = 15
    end
    object cdsProtNFedigVal: TStringField
      FieldName = 'digVal'
      Size = 28
    end
    object cdsProtNFecStat: TStringField
      FieldName = 'cStat'
      Size = 3
    end
    object cdsProtNFexMotivo: TStringField
      FieldName = 'xMotivo'
      Size = 24
    end
  end
  object dsProtNFe: TDataSource
    DataSet = cdsProtNFe
    Left = 16
    Top = 112
  end
  object cdsParcelasDaNota: TClientDataSet
    Aggregates = <>
    DataSetField = cdsNotaFiscaldup
    Params = <>
    Left = 15
    Top = 175
    object cdsParcelasDaNotanDup: TStringField
      FieldName = 'nDup'
      Size = 60
    end
    object cdsParcelasDaNotadVenc: TDateField
      FieldName = 'dVenc'
    end
    object cdsParcelasDaNotavDup: TStringField
      FieldName = 'vDup'
      Size = 31
    end
  end
end
