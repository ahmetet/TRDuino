Imports System.IO
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports FastColoredTextBoxNS

Public Class Form1

    Dim Kaynak As New AutoCompleteStringCollection()
    Dim Ana_Komutlar As New ArrayList
    Dim Serial_Komutlar As New ArrayList
    Dim IO_komutlar As New ArrayList
    Dim Tüm_komutlar As New ArrayList




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

gell:


        If (Directory.Exists(TempYolu)) Then
        Else

            Directory.CreateDirectory(TempYolu)
            GoTo gell
        End If

        eklenenler.Clear()

        BestTextBox.Focus()
        BestTextBox.Select()
        BestTextBox.Focus()

        BestTextBox.SelectionStart = 18

        BabaTab.Text = "Skeç1"

        Alt2.BackColor = Color.Black

        Try

            Dim portlar As String() = SerialPort.GetPortNames()
            For Each portcuk In portlar
                Dim yeni As ToolStripMenuItem = New ToolStripMenuItem(portcuk)
                PortToolStripMenuItem.DropDownItems.Add(yeni)
                AddHandler yeni.Click, AddressOf portsec
            Next

            If (portlar.Length = 1) Then
                SecilenPort = portlar(0).ToString
                porttool.Text = SecilenPort
            End If
        Catch ex As Exception
            log.Text += ex.Message
        End Try


    End Sub

    Private Sub YeniToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YeniToolStripMenuItem.Click

        BestTextBox.SelectionStart = 67
        Try

            If (SonKarakter(BabaTab.Text, 0) = "*") Then
                If (tempyol = "yok") Then
                    Dim sonuc As Integer = MessageBox.Show("Dosyanız kaydedilsin mi?", "Dosyanızı kaydetmediniz!", MessageBoxButtons.YesNoCancel)
                    If (sonuc = DialogResult.Yes) Then
                        KaydetToolStripMenuItem.PerformClick()
                    ElseIf (sonuc = DialogResult.No) Then
                        BestTextBox.Clear()
                        BestTextBox.Text = Label2.Text
                        BabaTab.Text = "Yeni Skeç"
                        log.Text += "Yeni Skeç Yüklendi! 8" + vbNewLine
                        tempyol = "yok"
                    ElseIf (sonuc = DialogResult.Cancel) Then

                    End If
                End If
            Else
                BestTextBox.Clear()
                BestTextBox.Text = Label2.Text
                BabaTab.Text = "Yeni Skeç"
                log.Text += "Yeni Skeç Yüklendi! 9" + vbNewLine
                tempyol = "yok"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function SonKarakter(ByVal str As String, ByVal mode As Integer) As String
        Try
            If (mode = 1) Then
                str = str.Substring(0, str.Length - 1)
                Return str
            Else
                str = str.Substring(str.Length - 1, 1)
                Return str
            End If
        Catch ex As Exception

        End Try
        Return 0
    End Function
    Dim tempyol As String = "yok"

    Private Sub KaydetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KaydetToolStripMenuItem.Click

        Poortextbox1_yedek.Text = BestTextBox.Text
        kodlarorjinal.Text = BestTextBox.Text ' sonradan

        If (derlemekmi = True) Then



            Try
                ' İşlem başarılıysa eğer
                SaveFileDialog1.Filter = "TRduino Kod Dosyası(*.tr)|*.tr|TRduino Referans Dosyası(*.trr)|*.trr"

                If (tempyol = "yok") Then
                    Dim SkecAdı As String
                    SkecAdı = InputBox("Bir Skeç Adı Giriniz", "Skeç Adı")
                    SaveFileDialog1.FileName = SkecAdı


                    If (SaveFileDialog1.ShowDialog = DialogResult.OK) Then

                        If (SaveFileDialog1.FilterIndex = 1) Then
                            ino_or_amo = "tr"

                            If (System.IO.Directory.Exists(SaveFileDialog1.FileName.Replace(".tr", ""))) Then
                                Dim olanyol As String = SaveFileDialog1.FileName.Replace(".tr", "") + "\" + SkecAdı + ".tr"
                                kodlarorjinal.SaveFile(olanyol, RichTextBoxStreamType.PlainText)
                                tempyol = SaveFileDialog1.FileName.Replace(".tr", "") + "\" + SkecAdı + ".tr"


                                KaydetToolStripMenuItem.PerformClick()


                            Else

                                System.IO.Directory.CreateDirectory(SaveFileDialog1.FileName.Replace(".tr", ""))
                                Dim olusturulanyol As String = SaveFileDialog1.FileName.Replace(".tr", "") + "\"
                                kodlarorjinal.SaveFile(olusturulanyol + SkecAdı + ".tr", RichTextBoxStreamType.PlainText)
                                tempyol = SaveFileDialog1.FileName.Replace(".tr", "") + "\" + SkecAdı + ".tr"


                                KaydetToolStripMenuItem.PerformClick()


                            End If
                        Else
                            ino_or_amo = "tr"
                            If (System.IO.Directory.Exists(SaveFileDialog1.FileName.Replace(".trr", ""))) Then
                                Dim olanyol As String = SaveFileDialog1.FileName.Replace(".trr", "") + "\" + SkecAdı + ".trr"
                                kodlarorjinal.SaveFile(olanyol, RichTextBoxStreamType.PlainText)
                                tempyol = SaveFileDialog1.FileName.Replace(".trr", "") + "\" + SkecAdı + ".trr"





                            Else

                                System.IO.Directory.CreateDirectory(SaveFileDialog1.FileName.Replace(".trr", ""))
                                Dim olusturulanyol As String = SaveFileDialog1.FileName.Replace(".trr", "") + "\"
                                kodlarorjinal.SaveFile(olusturulanyol + SkecAdı + ".trr", RichTextBoxStreamType.PlainText)
                                tempyol = SaveFileDialog1.FileName.Replace(".trr", "") + "\" + SkecAdı + ".trr"





                            End If
                        End If



                        BabaTab.Text = SonKarakter(BabaTab.Text, 1)


                        BabaTab.Text = SkecAdı
                        '       SonuncuyuAçToolStripMenuItem.DropDownItems.Add(SkecAdı)
                        Dim yeni As ToolStripMenuItem = New ToolStripMenuItem(SkecAdı)

                        SonuncuyuAçToolStripMenuItem.DropDownItems.Add(yeni)

                        ListBox1.Items.Add(SkecAdı)
                        ListBox2.Items.Add(SaveFileDialog1.FileName)

                        AddHandler yeni.Click, AddressOf tikla_ac


                        log.Text += SkecAdı + " Adlı proje başarıyla kaydedildi!" + vbNewLine
                    Else

                    End If
                Else
                    kodlarorjinal.SaveFile(tempyol, RichTextBoxStreamType.PlainText)
                    If (SonKarakter(BabaTab.Text, 0) = "*") Then
                        BabaTab.Text = SonKarakter(BabaTab.Text, 1)
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        Else
            Try
                ' İşlem başarılıysa eğer
                SaveFileDialog1.Filter = "TRduino Kod Dosyası(*.tr)|*.tr|TRduino Referans Dosyası(*.trr)|*.trr"

                If (tempyol = "yok") Then
                    Dim SkecAdı As String
                    SkecAdı = InputBox("Bir Skeç Adı Giriniz", "Skeç Adı")
                    SaveFileDialog1.FileName = SkecAdı


                    If (SaveFileDialog1.ShowDialog = DialogResult.OK) Then

                        If (SaveFileDialog1.FilterIndex = 1) Then
                            ino_or_amo = "tr"

                            If (System.IO.Directory.Exists(SaveFileDialog1.FileName.Replace(".tr", ""))) Then
                                Dim olanyol As String = SaveFileDialog1.FileName.Replace(".tr", "") + "\" + SkecAdı + ".tr"
                                kodlarorjinal.SaveFile(olanyol, RichTextBoxStreamType.PlainText)
                                tempyol = SaveFileDialog1.FileName.Replace(".tr", "") + "\" + SkecAdı + ".tr"
                                KaydetToolStripMenuItem.PerformClick()
                            Else

                                System.IO.Directory.CreateDirectory(SaveFileDialog1.FileName.Replace(".tr", ""))
                                Dim olusturulanyol As String = SaveFileDialog1.FileName.Replace(".tr", "") + "\"
                                kodlarorjinal.SaveFile(olusturulanyol + SkecAdı + ".tr", RichTextBoxStreamType.PlainText)
                                tempyol = SaveFileDialog1.FileName.Replace(".tr", "") + "\" + SkecAdı + ".tr"
                                KaydetToolStripMenuItem.PerformClick()
                            End If
                        Else
                            ino_or_amo = "trr"
                            If (System.IO.Directory.Exists(SaveFileDialog1.FileName.Replace(".trr", ""))) Then
                                Dim olanyol As String = SaveFileDialog1.FileName.Replace(".trr", "") + "\" + SkecAdı + ".trr"
                                kodlarorjinal.SaveFile(olanyol, RichTextBoxStreamType.PlainText)
                                tempyol = SaveFileDialog1.FileName.Replace(".trr", "") + "\" + SkecAdı + ".trr"

                            Else

                                System.IO.Directory.CreateDirectory(SaveFileDialog1.FileName.Replace(".trr", ""))
                                Dim olusturulanyol As String = SaveFileDialog1.FileName.Replace(".trr", "") + "\"
                                kodlarorjinal.SaveFile(olusturulanyol + SkecAdı + ".trr", RichTextBoxStreamType.PlainText)
                                tempyol = SaveFileDialog1.FileName.Replace(".trr", "") + "\" + SkecAdı + ".trr"

                            End If
                        End If



                        BabaTab.Text = SonKarakter(BabaTab.Text, 1)

                        BabaTab.Text = SkecAdı
                        '       SonuncuyuAçToolStripMenuItem.DropDownItems.Add(SkecAdı)
                        Dim yeni As ToolStripMenuItem = New ToolStripMenuItem(SkecAdı)
                        SonuncuyuAçToolStripMenuItem.DropDownItems.Add(yeni)
                        ListBox1.Items.Add(SkecAdı)
                        ListBox2.Items.Add(SaveFileDialog1.FileName)
                        AddHandler yeni.Click, AddressOf tikla_ac
                        log.Text += SkecAdı + " Adlı proje başarıyla kaydedildi! 10" + vbNewLine
                    Else

                    End If
                Else
                    '      Poortextbox1_yedek.Text = BestTextBox.Text
                    kodlarorjinal.SaveFile(tempyol, RichTextBoxStreamType.PlainText)
                    If (SonKarakter(BabaTab.Text, 0) = "*") Then
                        BabaTab.Text = SonKarakter(BabaTab.Text, 1)
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If



    End Sub

    Private Sub tikla_ac(ByVal sender As Object, ByVal e As EventArgs)
        Dim istenen As String = CType(sender, ToolStripMenuItem).Text
        MessageBox.Show((ListBox2.Items.Item(ListBox1.Items.IndexOf(istenen))))
        Poortextbox1_yedek.LoadFile(ListBox2.Items.Item(ListBox1.Items.IndexOf(istenen)), RichTextBoxStreamType.PlainText)
        BestTextBox.Text = Poortextbox1_yedek.Text
        BabaTab.Text = OpenFileDialog1.SafeFileName.Replace(".ino", "")
        log.Text += OpenFileDialog1.SafeFileName + " Adlı proje başarıyla açıldı! 11" + vbNewLine

    End Sub
    Dim SecilenPort As String = "yok"
    Private Sub portsec(ByVal sender As Object, ByVal e As EventArgs)
        Dim istenen = CType(sender, ToolStripMenuItem)
        SecilenPort = istenen.Text
        porttool.Text = SecilenPort.ToString
    End Sub

    Dim keyboard_control As Boolean

    Dim keyboard_S As Boolean
    Dim keyboard_N As Boolean
    Dim keyboard_O As Boolean
    Dim keyboard_U As Boolean
    Dim keyboard_W As Boolean
    Dim keyboard_Q As Boolean
    Dim keyboard_F5 As Boolean
    Dim keyboard_D As Boolean
    Dim keyboard_Z As Boolean
    Dim keyboard_Y As Boolean
    Dim keyboard_space As Boolean
    Dim keyboard_shift As Boolean
    Dim keyboard_M As Boolean
    Dim anahtar As String = ""
    Dim onceki_anahtar As String = ""
    Dim sondan As Integer
    Dim bastan As Integer
    'CTRL_S
    'CTRL_N
    'CTRL_O
    'CTRL_W
    'CTRL_Q

    Private Sub BestTextBox_Keydowncuk(sender As Object, e As KeyEventArgs) Handles BestTextBox.KeyDown



        'If e.KeyCode = Keys.Enter Then
        '    Renklendir()
        'End If






        If e.KeyCode = Keys.ControlKey Then
            keyboard_control = True
            enson_cursor = CType(sender, FastColoredTextBox).SelectionStart




        ElseIf (e.KeyCode = Keys.S) Then
            keyboard_S = True
            If (keyboard_control = True) Then

                KaydetToolStripMenuItem.PerformClick()
                'Renklendir()
                keyboard_control = False
                keyboard_S = False
            End If

        ElseIf (e.KeyCode = Keys.N) Then
            keyboard_N = True
            If (keyboard_control = True) Then
                YeniToolStripMenuItem.PerformClick()
                keyboard_control = False
                keyboard_N = False
            End If

        ElseIf (e.KeyCode = Keys.O) Then
            keyboard_O = True
            If (keyboard_control = True) Then
                AçCTRLOToolStripMenuItem.PerformClick()
                keyboard_control = False
                keyboard_O = False
            End If

        ElseIf (e.KeyCode = Keys.W) Then
            keyboard_W = True
            If (keyboard_control = True) Then

                keyboard_control = False
            End If

        ElseIf (e.KeyCode = Keys.Q) Then
            keyboard_Q = True
            If (keyboard_control = True) Then
                Me.Close()
                keyboard_control = False
                keyboard_Q = False
            End If
        ElseIf (e.KeyCode = Keys.F5) Then
            keyboard_F5 = True
            If (keyboard_control = True) Then
                DoğrulaDerleToolStripMenuItem.PerformClick()
                keyboard_control = False
                keyboard_F5 = False
            End If
        ElseIf (e.KeyCode = Keys.U) Then
            keyboard_U = True
            If (keyboard_control = True) Then
                DoğrulaDerleToolStripMenuItem.PerformClick()
                keyboard_control = False
                keyboard_U = False
            End If
        ElseIf (e.KeyCode = Keys.Z) Then
            keyboard_Z = True
            If (keyboard_control = True) Then
                CType(sender, FastColoredTextBox).Undo()
                keyboard_control = False
                keyboard_Z = False
            End If
        ElseIf (e.KeyCode = Keys.Y) Then
            keyboard_Y = True
            If (keyboard_control = True) Then
                CType(sender, FastColoredTextBox).Redo()
                keyboard_control = False
                keyboard_Y = False
            End If

        ElseIf (e.KeyCode = Keys.D) Then

            'Eğer seçilen şey daha önce tanımlanmadıysa,o seçilen isimde yeni bir değişken tanımlar.
            'daha önce tanımlandıysa direk o şeye bürünür
            'Burada "Değişken" anahtar kelimesini kullanarak ide'ye "var" eklemiş oluyorum :))

            keyboard_D = True

            If (keyboard_control = True) Then

                'Eğer seçilen değişken daha önce tanımlandıysa/tanımlanmadıysa
                For Each degiskencik In _degiskenler.Items
                        'tür@değişken_adı@değişken_değeri
                        If (degiskencik.ToString.Split("@")(1).ToString = BestTextBox.SelectedText.ToString) Then
                            'Burada değiştirme öne sürülebilir ilerleyen zaamanlarda.
                            GoTo bitir
                        End If
                    Next


                    Dim degisken_adi As String = "" 'değişken adı
                    Dim eskiyer As Integer = BestTextBox.SelectionStart ' eskiyeri sapta

                    'Eğer seçilen şey hiçbir şeyse/değilse
                    If (BestTextBox.SelectedText.Trim = "") Then
                        'hiçbir şey seçmediin demek ya da boşluk seçtin demek
                    Else
                        degisken_adi = BestTextBox.SelectedText
                    End If


                    Dim degisken_deger As String = InputBox("Lütfen '" + degisken_adi + "' değişkenine verilecek değeri giriniz;", "Hızlı Değişken")
                    If (Not degisken_deger.Trim = "") Then ' eğer değişken değeri hiçbir şey girilmediyse ya da boşluk girilmediyse
                        BestTextBox.SelectedText = degisken_adi
                        EnUsteGit_Ve_Ekle("Değişken " + degisken_adi + " = " + degisken_deger + ";")
                        Dim _DEGISKEN As String = "Değişken@" + degisken_adi + "@" + degisken_deger
                        _degiskenler.Items.Add(_DEGISKEN)
                        BestTextBox.SelectionStart = eskiyer + degisken_adi.Length + 2  'eski yere git
                        'islem bitir
                    End If



bitir:
                    keyboard_control = False
                    keyboard_D = False
                End If





            Else
            keyboard_control = False
            sense.Visible = False
        End If


    End Sub
    Private Sub referanslar_icin(sender As Object, e As KeyEventArgs)

        'If e.KeyCode = Keys.Enter Then
        '    Renklendir()
        'End If

        If e.KeyCode = Keys.ControlKey Then
            keyboard_control = True
            enson_cursor = CType(sender, FastColoredTextBox).SelectionStart

        ElseIf (e.KeyCode = Keys.S) Then
            keyboard_S = True
            If (keyboard_control = True) Then

                'Bu dosyayı ait olduğu gibi kaydet.
                'Dim gecici As New RichTextBox
                'gecici.Text = CType(sender, FastColoredTextBox).Text
                Try


                    Dim adrescik As String = CType(sender, FastColoredTextBox).Parent.Tag.ToString
                    File.WriteAllText(adrescik, CType(sender, FastColoredTextBox).Text, System.Text.Encoding.Default)
                Catch ex As Exception
                    log.Text += vbNewLine + "Hatacık 23 : " + ex.Message + vbNewLine
                End Try


                keyboard_control = False
                keyboard_S = False
            End If


        ElseIf (e.KeyCode = Keys.Z) Then
            keyboard_Z = True
            If (keyboard_control = True) Then
                CType(sender, FastColoredTextBox).Undo()
                keyboard_control = False
                keyboard_Z = False
            End If
        ElseIf (e.KeyCode = Keys.Y) Then
            keyboard_Y = True
            If (keyboard_control = True) Then
                CType(sender, FastColoredTextBox).Redo()
                keyboard_control = False
                keyboard_Y = False
            End If


        Else
            keyboard_control = False
            sense.Visible = False
        End If

    End Sub
    Dim enson_cursor As Integer
    Dim k As Integer = 0
    Private Sub BestTextBox_tEXtchanged(sender As Object, e As EventArgs)
        If (SonKarakter(BabaTab.Text, 0) = "*") Then
        Else
            BabaTab.Text = BabaTab.Text + "*"
        End If

    End Sub

    Private Sub AçCTRLOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AçCTRLOToolStripMenuItem.Click
        Try
            OpenFileDialog1.Filter = "TRduino Kod Dosyası(*.tr)|*.tr|Arduino Kod Dosyası(*.ino)|*.ino"

            If (OpenFileDialog1.ShowDialog = DialogResult.OK) Then
                Poortextbox1_yedek.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                BestTextBox.Text = Poortextbox1_yedek.Text
                If (OpenFileDialog1.FilterIndex = 1) Then

                    '   BestTextBox.Text = BestTextBox.Text.Replace("fonksiyon ayarlar", "void setup").Replace("fonksiyon tekrarlar", "void loop").Replace("pindurumu", "pinMode").Replace("çıkış", "OUTPUT").Replace("giriş", "INPUT").Replace("bekle", "delay").Replace("söndür", "LOW").Replace("yak", "HIGH").Replace("analogoku", "analogRead").Replace("dijitaloku", "digitalRead").Replace("iletişim", "Serial").Replace(".başlat", ".begin").Replace(".hazırsa", ".available").Replace("eğer", "if").Replace("ya da", "else if").Replace("aksi halde", "else").Replace("değilse", "else").Replace(".gönderasg", ".println").Replace(".gönder", ".print").Replace(".oku", ".read").Replace(".bitir", ".end").Replace("doğru", "true").Replace("yanlış", "false").Replace("gömülü_led", "LED_BUILTIN").Replace("karttaki_led", "LED_BUILTIN").Replace("bayta_dönüştür", "byte").Replace("karaktere_dönüştür", "char").Replace("reel_sayıya_dönüştür", "float").Replace("tam_sayıya_dönüştür", "int").Replace("kelimeye_dönüştür", "String").Replace("dizi", "array").Replace("mantıksal", "boolean").Replace("karakter", "char").Replace("reel sayı", "float").Replace("tam sayı", "int").Replace("kelime", "string").Replace("pozitif karakter", "unsigned char").Replace("pozitif tam sayı", "unsigned int").Replace("mantıksal fonksiyon", "bool").Replace("kelime fonksiyon", "String").Replace("karakter fonksiyon", "char").Replace("reel sayı fonksiyon", "float").Replace("tam sayı fonksiyon", "int").Replace("fonksiyon", "void").Replace("sabit", "const").Replace("giriş_pullup", "INPUT_PULLUP").Replace("a0", "A0").Replace("a1", "A1").Replace("a2", "A2").Replace("a3", "A3").Replace("a4", "A4").Replace("a5", "A5").Replace("a6", "A6").Replace("a7", "A7").Replace("a8", "A8")

                Else

                    BestTextBox.Text = BestTextBox.Text.Replace("void setup", "Fonksiyon Ayarlar").Replace("void loop", "Fonksiyon Tekrarlar").Replace("unsigned Char", "Pozitif Karakter").Replace("unsigned int", "Pozitif Tam Sayı").Replace("return", "Döndür").Replace("pinMode", "PinDurumu").Replace("OUTPUT", "ÇIKIŞ").Replace("INPUT", "GİRİŞ").Replace("delay", "Bekle").Replace("LOW", "PASİF").Replace("HIGH", "AKTİF").Replace("analogRead", "AnalogOku").Replace("digitalRead", "DijitalOku").Replace("Serial", "İletişim").Replace(".begin", ".Başlat").Replace(".available", ".Hazırsa").Replace("if", "Eğer").Replace("else if", "Ya da").Replace("else", "Aksi halde").Replace(".println", ".GönderASG").Replace(".print", ".Gönder").Replace(".read", ".Oku").Replace(".End", ".Bitir").Replace("True", "DOĞRU").Replace("False", "YANLIŞ").Replace("LED_BUILTIN", "GÖMÜLÜ_LED").Replace("int", "Tam Sayı").Replace("char", "Karakter").Replace("float", "Reel Sayı").Replace("array", "Dizi").Replace("boolean", "Mantıksal").Replace("String", "Kelime").Replace("digitalWrite", "Yaz").Replace("analogWrite", "Yaz").Replace("void", "Fonksiyon").Replace("for", "Döngü").Replace("while", "Döngü").Replace("a0", "A0")


                End If


                BabaTab.Text = OpenFileDialog1.SafeFileName.Replace(".ino", "").Replace(".tr", "")
                log.Text += OpenFileDialog1.SafeFileName + " Adlı proje başarıyla açıldı! 12" + vbNewLine
                tempyol = OpenFileDialog1.FileName

                Dim yeni As ToolStripMenuItem = New ToolStripMenuItem(OpenFileDialog1.SafeFileName)
                SonuncuyuAçToolStripMenuItem.DropDownItems.Add(BabaTab.Text)
                ListBox1.Items.Add(BabaTab.Text)
                ListBox2.Items.Add(OpenFileDialog1.FileName)
                AddHandler yeni.Click, AddressOf tikla_ac

            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub HakkındaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HakkındaToolStripMenuItem.Click
        log.Text = log.Text + vbNewLine
        log.AppendText(" Ahmetet ")
        log.Text = log.Text + vbNewLine
        log.Find("Ahmetet")
        log.SelectionColor = Color.Red

        log.Text = log.Text + vbNewLine
        log.AppendText(" Nobody ")
        log.Text = log.Text + vbNewLine
        log.Find("Nobody")
        log.SelectionColor = Color.Red

    End Sub

    Private Sub FormKapanmadan(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (SonKarakter(BabaTab.Text, 0) = "*") Then
            If (tempyol = "yok") Then
                SaveFileDialog1.Filter = "TRduino Kod Dosyası(*.tr)|*.tr|Arduino Kod Dosyası(*.ino)|*.ino"
                If (tempyol = "yok") Then
                    If (SaveFileDialog1.ShowDialog = DialogResult.OK) Then
                        Poortextbox1_yedek.Text = BestTextBox.Text
                        Poortextbox1_yedek.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                        tempyol = SaveFileDialog1.FileName
                    Else

                    End If
                Else
                    Poortextbox1_yedek.Text = BestTextBox.Text
                    Poortextbox1_yedek.SaveFile(tempyol, RichTextBoxStreamType.PlainText)
                End If
            Else
                KaydetToolStripMenuItem.PerformClick()
            End If
        Else
            SaveFileDialog1.Filter = "TRduino Kod Dosyası(*.tr)|*.tr|Arduino Kod Dosyası(*.ino)|*.ino"
            If (tempyol = "yok") Then
                If (SaveFileDialog1.ShowDialog = DialogResult.OK) Then
                    Poortextbox1_yedek.Text = BestTextBox.Text
                    Poortextbox1_yedek.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                    tempyol = SaveFileDialog1.FileName
                Else

                End If
            Else
                KaydetToolStripMenuItem.PerformClick()
            End If
        End If
    End Sub

    Private Sub DoğrulaDerleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoğrulaDerleToolStripMenuItem.Click
        TamDerle()
    End Sub

    Dim HexTamYol As String = "yok"
    Private Sub Derle()
        Try
            BasitDonustur()
        Catch ex As Exception
            log.Text += "Bir hata meydana geldi: 13 " + ex.Message + vbNewLine
        End Try

    End Sub
    Dim ino_or_amo As String

    Dim referans_bayrak As Integer = 0
    Private Sub BasitDonustur()
        referans_bayrak = 0
        Dim alinanlar As New ArrayList
        alinanlar.Clear()

        Try

            Poortextbox1_yedek.Text = BestTextBox.Text
            Dim eskiyer As Integer = Poortextbox1_yedek.SelectionStart
            asilislem.Clear()
            'Dim ızgara As String = Poortextbox1_yedek.Text.ToLower

            Dim çevrilmiş As String = ""


            'Regex ile yap
            '  asilislem.Text = ızgara.Replace("fonksiyon ayarlar", "void setup").Replace("fonksiyon tekrarlar", "void loop").Replace("pindurumu", "pinMode").Replace("çıkış", "OUTPUT").Replace("giriş", "INPUT").Replace("bekle", "delay").Replace("söndür", "LOW").Replace("yak", "HIGH").Replace("analogoku", "analogRead").Replace("dijitaloku", "digitalRead").Replace("iletişim", "Serial").Replace(".başlat", ".begin").Replace(".hazırsa", ".available").Replace("eğer", "if").Replace("ya da", "else if").Replace("aksi halde", "else").Replace("değilse", "else").Replace(".gönderasg", ".println").Replace(".gönder", ".print").Replace(".oku", ".read").Replace(".bitir", ".end").Replace("doğru", "true").Replace("yanlış", "false").Replace("gömülü_led", "LED_BUILTIN").Replace("karttaki_led", "LED_BUILTIN").Replace("bayta_dönüştür", "byte").Replace("karaktere_dönüştür", "char").Replace("reel_sayıya_dönüştür", "float").Replace("tam_sayıya_dönüştür", "int").Replace("kelimeye_dönüştür", "String").Replace("dizi", "array").Replace("mantıksal", "boolean").Replace("karakter", "char").Replace("reel sayı", "float").Replace("tam sayı", "int").Replace("kelime", "string").Replace("pozitif karakter", "unsigned char").Replace("pozitif tam sayı", "unsigned int").Replace("mantıksal fonksiyon", "bool").Replace("kelime fonksiyon", "String").Replace("karakter fonksiyon", "char").Replace("reel sayı fonksiyon", "float").Replace("tam sayı fonksiyon", "int").Replace("fonksiyon", "void").Replace("sabit", "const").Replace("giriş_pullup", "INPUT_PULLUP").Replace("a0", "A0").Replace("a1", "A1").Replace("a2", "A2").Replace("a3", "A3").Replace("a4", "A4").Replace("a5", "A5").Replace("a6", "A6").Replace("a7", "A7").Replace("a8", "A8").Replace("bayt", "byte")
            '  asilislem.Text = Regex.Replace(Poortextbox1_yedek.Text, "fonksiyon ayarlar", "void setup", RegexOptions.IgnoreCase)


            'Her şeyin öncesinde 'var' yani "Değişken" anahtar kelimesini düzgün bir şekilde optimize et;


            Dim temb As Integer = 0
            While (temb < Poortextbox1_yedek.Lines.Length)

                If (Poortextbox1_yedek.Lines(temb).ToLower.Contains("değişken")) Then

                    Dim k As String = Poortextbox1_yedek.Lines(temb)
                    Poortextbox1_yedek.Find(k)


                    Dim dadi As String = Regex.Replace(Poortextbox1_yedek.SelectedText, "değişken", "", RegexOptions.IgnoreCase).Split("=")(0).Trim
                    Dim ddegeri As String = Regex.Replace(Poortextbox1_yedek.SelectedText, "değişken", "", RegexOptions.IgnoreCase).Split("=")(1).Trim.Replace(";", "")
                    'Poortextbox1_yedek.SelectedText = Regex.Replace(k, "değişken", " ", RegexOptions.IgnoreCase)


                    Dim intcik As Integer
                    Dim doublecik As Double

                    If (Integer.TryParse(ddegeri, intcik)) Then
                        '  MsgBox(" Tam Sayı")
                        Poortextbox1_yedek.SelectedText = Regex.Replace(k, "değişken", "Tam Sayı", RegexOptions.IgnoreCase)
                    ElseIf (Double.TryParse(ddegeri, doublecik)) Then
                        '       MsgBox("Reel Sayı")
                        Poortextbox1_yedek.SelectedText = Regex.Replace(k, "değişken", "Reel Sayı", RegexOptions.IgnoreCase)
                    ElseIf (ddegeri.ToLower = "doğru") Then
                        '      MsgBox("doğru Mantıksal")
                        Poortextbox1_yedek.SelectedText = Regex.Replace(k, "değişken", "Mantıksal", RegexOptions.IgnoreCase)
                    ElseIf (ddegeri.ToLower = "yanlış") Then
                        'MsgBox("yanlış Mantıksal")
                        Poortextbox1_yedek.SelectedText = Regex.Replace(k, "değişken", "Mantıksal", RegexOptions.IgnoreCase)
                    ElseIf (ddegeri.Contains("'")) Then
                        '    MsgBox("Karatker")
                        Poortextbox1_yedek.SelectedText = Regex.Replace(k, "değişken", "Karakter", RegexOptions.IgnoreCase)
                    ElseIf (ddegeri.Contains("""")) Then
                        '  MsgBox("Kelime")
                        Poortextbox1_yedek.SelectedText = Regex.Replace(k, "değişken", "Kelime", RegexOptions.IgnoreCase)
                    End If



                End If

                    temb += 1
            End While



adim1:

            If (referans_bayrak = 1) Then

                referans_bayrak = 2
            End If
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "fonksiyon ayarlar", "void setup", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "fonksiyon tekrarlar", "void loop", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "mantıksal fonksiyon", "bool", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "kelime fonksiyon", "String", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "karakter fonksiyon", "char", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "reel sayı fonksiyon", "float", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "tam sayı fonksiyon", "int", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "fonksiyon", "void", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "pindurumu", "pinMode", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "çıkış", "OUTPUT", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "giriş", "INPUT", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "bekle", "delay", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "söndür", "LOW", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "yak", "HIGH", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "analogoku", "analogRead", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "dijitaloku", "digitalRead", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "iletişim", "Serial", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, ".başlat", ".begin", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, ".hazırsa", ".available", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "eğer", "if", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "ya da", "else if", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "aksi halde", "else", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "değilse", "else", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, ".gönderasg", ".println", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, ".gönder", ".print", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, ".oku", ".read", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, ".bitir", ".end", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "doğru", "true", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "yanlış", "false", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "gömülü_led", "LED_BUILTIN", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "karttaki_led", "LED_BUILTIN", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "bayta_dönüştür", "byte", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "karaktere_dönüştür", "char", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "reel_sayıya_dönüştür", "float", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "tam_sayıya_dönüştür", "int", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "kelimeye_dönüştür", "String", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "dizi", "array", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "mantıksal", "boolean", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "karakter", "char", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "reel sayı", "float", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "tam sayı", "int", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "kelime", "String", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "pozitif karakter", "unsigned char", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "pozitif tam sayı", "unsigned int", RegexOptions.IgnoreCase)

            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "sabit", "const", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "giriş_pullup", "INPUT_PULLUP", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a0", "A0", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a1", "A1", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a2", "A2", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a3", "A3", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a4", "A4", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a5", "A5", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a6", "A6", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a7", "A7", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "a8", "A8", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "bayt", "byte", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "döndür", "return", RegexOptions.IgnoreCase)




            'Yaz(15,aktif)
            'yaz(13,pasif)


            Dim b As Integer = 0
            While (b < Poortextbox1_yedek.Lines.Length)

                If (Poortextbox1_yedek.Lines(b).ToLower.Contains("yaz") And Poortextbox1_yedek.Lines(b).ToLower.Contains("aktif")) Then
                    'satır b


                    Dim sonhal As String = Poortextbox1_yedek.Lines(b).Replace("yaz", "digitalWrite")

                    Dim k As String = Poortextbox1_yedek.Lines(b)
                    Poortextbox1_yedek.Find(k)
                    Poortextbox1_yedek.SelectedText = Regex.Replace(k, "yaz", "digitalWrite", RegexOptions.IgnoreCase)

                    '  Degis(sonhal, b, Poortextbox1_yedek)
                ElseIf (Poortextbox1_yedek.Lines(b).ToLower.Contains("yaz") And Poortextbox1_yedek.Lines(b).ToLower.Contains("pasif")) Then
                    'satır b
                    Dim sonhal As String = Poortextbox1_yedek.Lines(b).Replace("yaz", "digitalWrite")
                    Dim k As String = Poortextbox1_yedek.Lines(b)
                    Poortextbox1_yedek.Find(k)
                    Poortextbox1_yedek.SelectedText = Regex.Replace(k, "yaz", "digitalWrite", RegexOptions.IgnoreCase)

                End If

                b += 1
            End While

            Dim b2 As Integer = 0
            While (b2 < Poortextbox1_yedek.Lines.Length)

                If (Poortextbox1_yedek.Lines(b2).ToLower.Contains("yaz(") And Not Poortextbox1_yedek.Lines(b2).ToLower.Contains("aktif") And Not Poortextbox1_yedek.Lines(b2).ToLower.Contains("pasif")) Then
                    'satır b2
                    Dim sonhal As String = Poortextbox1_yedek.Lines(b2).Replace("yaz", "analogWrite")
                    Dim k As String = Poortextbox1_yedek.Lines(b2)
                    Poortextbox1_yedek.Find(k)
                    Poortextbox1_yedek.SelectedText = Regex.Replace(k, "yaz", "analogWrite", RegexOptions.IgnoreCase)

                ElseIf (Poortextbox1_yedek.Lines(b2).ToLower.Contains("özeleğer")) Then
                    MsgBox("annen")
                End If

                b2 += 1
            End While

            Dim b3 As Integer = 0
            While (b3 < Poortextbox1_yedek.Lines.Length)

                If (Poortextbox1_yedek.Lines(b3).ToLower.Contains(";") And Poortextbox1_yedek.Lines(b3).ToLower.Contains("döngü")) Then

                    Dim sonhal As String = Poortextbox1_yedek.Lines(b3).Replace("döngü", "for")

                    Dim k As String = Poortextbox1_yedek.Lines(b3)
                    Poortextbox1_yedek.Find(k)
                    Poortextbox1_yedek.SelectedText = Regex.Replace(k, "döngü", "for", RegexOptions.IgnoreCase)

                ElseIf (Poortextbox1_yedek.Lines(b3).ToLower.Contains("döngü") And Not Poortextbox1_yedek.Lines(b3).ToLower.Contains(";")) Then

                    Dim sonhal As String = Poortextbox1_yedek.Lines(b3).Replace("döngü", "while")
                    Dim k As String = Poortextbox1_yedek.Lines(b3)
                    Poortextbox1_yedek.Find(k)
                    Poortextbox1_yedek.SelectedText = Regex.Replace(k, "döngü", "while", RegexOptions.IgnoreCase)

                End If

                b3 += 1
            End While

            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "aktif", "1", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "pasif", "0", RegexOptions.IgnoreCase) 'fark ettiysen method değiştirdik kendi içinden çevirdik ' ikinci kez okuduğumda anlamadım yav fadsdghf
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "yak", "1", RegexOptions.IgnoreCase)
            Poortextbox1_yedek.Text = Regex.Replace(Poortextbox1_yedek.Text, "söndür", "0", RegexOptions.IgnoreCase)







            'TERNARY İF'i 


            'Dim say As Integer = 0
            'While (say < Poortextbox1_yedek.Lines.Length)

            '    If (Regex.IsMatch(Poortextbox1_yedek.Lines(say), "(özeleğer|Özeleğer|ÖzelEğer|ÖZELEĞER)", RegexOptions.IgnoreCase)) Then
            '        MsgBox("yes")
            '        'satır say
            '        'ÖzelEğer(şart,olumlu,olumsuz)
            '        'ahmet>3 ? HIGH : LOW
            '        'ÖzelEğer(ahmet>3,HIGH,LOW)
            '        Dim eldeki_satir As String = Poortextbox1_yedek.Lines(say)
            '        eldeki_satir = Regex.Split(eldeki_satir, "özeleğer", RegexOptions.IgnoreCase)(1)
            '        eldeki_satir = eldeki_satir.Replace("(", "").Replace(")", "")
            '        Dim eldeki_satir_sart As String = eldeki_satir.Split(",")(0)
            '        Dim eldeki_satir_olumlu As String = eldeki_satir.Split(",")(1)
            '        Dim eldeki_satir_olumsuz As String = eldeki_satir.Split(",")(2)
            '        MsgBox(eldeki_satir_sart)
            '        MsgBox(eldeki_satir_olumlu)
            '        MsgBox(eldeki_satir_olumsuz)
            '        'Dim sonhal As String = Poortextbox1_yedek.Lines(say).Replace("özeleğer(", "analogWrite")
            '        'Dim k As String = Poortextbox1_yedek.Lines(say)
            '        'Poortextbox1_yedek.Find(k)
            '        'Poortextbox1_yedek.SelectedText = Regex.Replace(k, "yaz", "analogWrite", RegexOptions.IgnoreCase)

            '    End If

            '    say += 1
            'End While

            'TERNARY İF'i  bitir



            'Oku(pin,şekil)
            'OKu(13,Analog)
            'Oku(13,Dijital)

            'Dim c As Integer = 0
            'While (c < asilislem.Lines.Length)

            '    If (asilislem.Lines(c).ToLower.Contains("oku")) Then
            '        'OKU(13,
            '        If (asilislem.Lines(c).ToLower.Contains("analog")) Then
            '            'Oku(13,analog)
            '            Dim sonhal As String = asilislem.Lines(c).Replace("oku", "analogRead")
            '            Degis(sonhal.Replace(", analog", ""), c, asilislem)
            '            Dim pin As String = sonhal.Split(", ")(0).Split("(")(1).ToString
            '            Dim eklenecek As String
            '            eklenecek = "PinDurumu(" + pin + ", GİRİŞ)"
            '            If (islenenler.Items.Contains(pin)) Then
            '            Else
            '                Ekle("ayarlar", eklenecek)
            '                islenenler.Items.Add(pin)
            '            End If
            '        ElseIf (asilislem.Lines(c).ToLower.Contains("dijital")) Then
            '            Dim sonhal As String = asilislem.Lines(c).Replace("oku", "digitalRead")
            '            Degis(sonhal.Replace(", dijital", ""), c, asilislem)
            '            Dim pin As String = sonhal.Split(", ")(0).Split("(")(1).ToString
            '            Dim eklenecek As String
            '            eklenecek = "PinDurumu(" + pin + ", GİRİŞ)"
            '            If (islenenler.Items.Contains(pin)) Then
            '            Else
            '                Ekle("ayarlar", eklenecek)
            '                islenenler.Items.Add(pin)
            '            End If
            '        End If
            '    End If


            '    c += 1
            'End While

            'Referansları Dosya İçerisine aktar
            ' referans dosyalarının içeriğini sırayla al
            ' ve sırayla hepsini işle
            ' ve aynı şeyleri almamak için kontrol et,zaman kazandırır + hatayı önler
            Dim ahmetex As New Regex("<(.|\n)*?>")


            'Bir şeyler yaptık işte ruh halim boktan yazmakla uğraşamayacağım açıklamasını
            For Each Cumlecik In Poortextbox1_yedek.Lines
                If Cumlecik.Contains("Referans") And Cumlecik.Contains("#") And Cumlecik.Contains("<") And Cumlecik.Contains(">") Then

                    For Each m As Match In ahmetex.Matches(Cumlecik)
                        If (alinanlar.Contains(m.Value.ToString.Replace("<", "").Replace(">", ""))) Then

                        Else
                            alinanlar.Add(m.Value.ToString.Replace("<", "").Replace(">", ""))
                        End If

                    Next

                End If
            Next


            Dim icerik As New RichTextBox


            For Each Cumlecik In Poortextbox1_yedek.Lines
                If Cumlecik.Contains("Referans") Then


                    For Each m As Match In ahmetex.Matches(Cumlecik)

                        Try
                            Dim sifiryol As String = m.Value.ToString.Replace("<", "").Replace(">", "")
                            icerik.Clear()
                            icerik.LoadFile(sifiryol, RichTextBoxStreamType.PlainText)

                            Try

                                '    asilislem.Text = Regex.Replace(asilislem.Text, Cumlecik, icerik.Text, RegexOptions.IgnoreCase)
                                Poortextbox1_yedek.Text = Poortextbox1_yedek.Text.Replace(Cumlecik, vbNewLine + icerik.Text + vbNewLine)
                            Catch ex As Exception
                                log.Text += vbNewLine + "HATACIK 29 " + ex.Message + vbNewLine
                            End Try

                        Catch ex As Exception
                            log.Text += vbNewLine + "HATACIK " + ex.Message + vbNewLine

                        End Try
                    Next



                End If
            Next


            If (referans_bayrak = 2) Then

                GoTo gecis_izni

            Else

                referans_bayrak = 1
                GoTo adim1
            End If

gecis_izni:


            asilislem.Text = Poortextbox1_yedek.Text



            hataayıkla2()

        Catch ex As Exception

        End Try
    End Sub
    Dim atla As Boolean = 0
    Private Sub hataayıkla2()
        Dim toplam_suslu_acik_parantez As Integer
        Dim toplam_suslu_kapali_parantez As Integer
        'Dim olmasi_gereken_suslu_toplam_acik_parantez As Integer
        'Dim olmasi_gereken_suslu_toplam_kapali_parantez As Integer

        Dim toplam_normal_acik_parantez As Integer
        Dim toplam_normal_kapali_parantez As Integer
        'Dim olmasi_gereken_normal_toplam_acik_parantez As Integer
        'Dim olmasi_gereken_normal_toplam_kapali_parantez As Integer


        For Each objecik In Poortextbox1_yedek.Lines  ' Gördüğü süslü parantezleri sayıyor
            Try
                If (objecik.Substring(0, 1) = "/") Then
                    'geç
                Else
                    For Each objectikparcacigi In objecik
                        If (objectikparcacigi = "{") Then
                            toplam_suslu_acik_parantez += 1
                        ElseIf (objectikparcacigi = "}") Then
                            toplam_suslu_kapali_parantez += 1
                        ElseIf (objectikparcacigi = "(") Then
                            toplam_normal_acik_parantez += 1
                        ElseIf (objectikparcacigi = ")") Then
                            toplam_normal_kapali_parantez += 1
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try
        Next

        'OK   'Eğer fonksiyon kelimesi geçtiyse o kelimeyle beraber 2 adet te süslü parantez eklenmeli

        'Eğer yaz,idijtaioku,analogoku,bekle,pindurumu,başlat,gönder,gönderasg,hazırsa,bitir,oku(iletişi),dönüştür  geçtiyse her birisi için 2 şer normal parantez eklenmeli

        'OK   'Eğer, eğer geçtiyse iki normal iki süslü,ya da geçtiyse iki normal iki süslü,aksi halde geçtiyse iki süslü,değilse iki süslü olmalı


        'For Each thing In Poortextbox1_yedek.Text.ToLower.Split()
        '    If (thing.Contains("fonksiyon") Or thing.Contains("aksi") Or thing.Contains("değilse")) Then
        '        olmasi_gereken_suslu_toplam_acik_parantez += 1
        '        olmasi_gereken_suslu_toplam_kapali_parantez += 1
        '    ElseIf (thing.Contains("fonksiyon") Or thing.Contains("da") Or thing.Contains("eğer") Or thing.Contains("yaz") Or thing.Contains("dijitaloku") Or thing.Contains("analogoku") Or thing.Contains("bekle") Or thing.Contains("pindurumu") Or thing.Contains("başlat") Or thing.Contains("gönder") Or thing.Contains("gönderasg") Or thing.Contains("hazırsa") Or thing.Contains("bitir") Or thing.Contains("dönüştür") Or thing.Contains("iletşim.oku")) Then
        '        olmasi_gereken_normal_toplam_acik_parantez += 1
        '        olmasi_gereken_normal_toplam_kapali_parantez += 1
        '    End If
        'Next
        ''MessageBox.Show("Olması gerken { : " + olmasi_gereken_suslu_toplam_acik_parantez.ToString + vbNewLine + "Olması gereken } :" + olmasi_gereken_suslu_toplam_kapali_parantez.ToString + vbNewLine + "Olan { : " + toplam_suslu_acik_parantez.ToString + vbNewLine + "Olan } : " + toplam_suslu_kapali_parantez.ToString)
        '  MessageBox.Show("Olması gerken ( : " + olmasi_gereken_normal_toplam_acik_parantez.ToString + vbNewLine + "Olması gereken ) :" + olmasi_gereken_normal_toplam_kapali_parantez.ToString + vbNewLine + "Olan ( : " + toplam_normal_acik_parantez.ToString + vbNewLine + "Olan ) : " + toplam_normal_kapali_parantez.ToString)
        '   End
        If (toplam_suslu_acik_parantez = toplam_suslu_kapali_parantez) Then

            log.Text += "Derleme hatasız bir şekilde tamamlandı. 14" + vbNewLine
            Alt1.BackColor = Color.CornflowerBlue
            log.ForeColor = Color.White
            ProgressBar1.Value = 50
            durum.ForeColor = Color.White
            durum.Text = "Derleme tamamlandı."

            DERLEMEYEHAZIR()
        ElseIf (toplam_suslu_acik_parantez > toplam_suslu_kapali_parantez) Then
            Alt1.BackColor = Color.Aqua
            log.ForeColor = Color.Aqua
            durum.ForeColor = Color.Blue
            durum.Text = "Derleme sırasında hata meydana geldi!"
            tamderle_cikis = False
            log.Text += vbNewLine + "Süslü parantezleri kapatmayı unutmuşsunuz! 15" + vbNewLine
        ElseIf (toplam_suslu_kapali_parantez > toplam_suslu_acik_parantez) Then
            Alt1.BackColor = Color.Aqua
            log.ForeColor = Color.Aqua
            durum.ForeColor = Color.Blue
            tamderle_cikis = False
            durum.Text = "Derleme sırasında hata meydana geldi!"
            log.Text += vbNewLine + "Süslü parantezleri açmayı unutmuşsunuz! 16" + vbNewLine
        End If
    End Sub
    Dim derlemekmi As Boolean = False
    Private Sub DERLEMEYEHAZIR()


        Try
            derlemekmi = True  ' kaydet için flag
            KaydetToolStripMenuItem.PerformClick()
            Dim dosyayolu As String = tempyol
            derlemekmi = False ' kaydet için flag bitişi
            tamderle_cikis = True
        Catch ex As Exception
            log.Text += vbNewLine + "Bir hata meydana geldi! 17" + vbNewLine
        End Try


    End Sub

    Private Sub YükleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YükleToolStripMenuItem.Click
        Yukle()
    End Sub
    Dim ARDUYOL As String = "C:\arduino-1.8.1-windows\arduino-1.8.1"
    Dim tahtasec As String = ""

    ' Dim Evrensel As String = "C:\TRduino"
    Dim Evrensel As String = "C:\TRduino" 'Application.StartupPath + "\TRduino"
    Dim TempYolu As String = "C:\ArduAhmetTemp" 'Application.StartupPath + "\ArduAhmetTemp"
    Private Sub Yukle()
        Try
            For Each item In Process.GetProcesses
                If (item.ProcessName.ToString() = "cmd") Then
                    item.Kill()
                End If
            Next
        Catch ex As Exception

        End Try
        If My.Computer.FileSystem.FileExists(Evrensel + "\tempburaya") Then

        Else
            My.Computer.FileSystem.CreateDirectory(Evrensel + "\tempburaya")
        End If

        Try


            If (SecilenPort = "yok") Then
                durum.Text = "Lütfen port seçiniz!"
                log.Text += vbNewLine + "Lütfen port seçiniz! 17" + vbNewLine
            Else

                Dim tahta As String = ""
                If (tahtasec = "") Then
                    durum.Text = "Lütfen arduino modelini seçiniz!"
                Else

                    'temp dosya olustur türkçe ihtimalini yok ed
                    'C:\ArduAhmetTemp
furkan:

                    If (My.Computer.FileSystem.DirectoryExists(TempYolu)) Then
tekrargel:

                        asilislem.SaveFile(TempYolu + "\ArduAhmetTemp.ino", RichTextBoxStreamType.PlainText)
                        asilislem.SaveFile(TempYolu + "\ArduAhmetTemp.ino", RichTextBoxStreamType.PlainText)
                        asilislem.SaveFile(TempYolu + "\ArduAhmetTemp.ino", RichTextBoxStreamType.PlainText)
                        asilislem.SaveFile(TempYolu + "\ArduAhmetTemp.ino", RichTextBoxStreamType.PlainText)






                        tahta = tahtasec
                        ' C:\arduino-1.8.1-windows\arduino-1.8.1
                        If ARDUYOL = "yok" Then

                            'SEÇ
                        Else
                            'Devam

                            'İLK BUİLD
                            Dim avrcik As String = ""
                            If (tahtasec = "nano") Then
                                avrcik = "nano"
                            ElseIf (tahtasec = "uno") Then
                                avrcik = "uno"
                            End If

                            Dim AhmetSon As String = Evrensel + "\arduino-builder -dump-prefs -logger=machine -hardware " + Evrensel + "\hardware -tools" + Evrensel + "\tools-builder -tools " + Evrensel + "\hardware\tools\avr -built-in-libraries " + Evrensel + "\libraries -fqbn=arduino:avr:" + avrcik + ":cpu=atmega328 -build-path " + Evrensel + "\tempburaya -warnings=none -prefs=build.warn_data_percentage=75 -prefs=runtime.tools.avr-gcc.path=" + Evrensel + "\hardware\tools\avr -prefs=runtime.tools.avrdude.path=" + Evrensel + "\hardware\tools\avr -prefs=runtime.tools.arduinoOTA.path=" + Evrensel + "\hardware\tools\avr -verbose " + TempYolu + "\ArduAhmetTemp.ino"
                            'İKİNCİ BUİLD + HEX
                            Dim AhmetSon2 As String = Evrensel + "\arduino-builder -compile -logger=machine -hardware " + Evrensel + "\hardware -tools " + Evrensel + "\tools-builder -tools " + Evrensel + "\hardware\tools\avr -built-in-libraries " + Evrensel + "\libraries -fqbn=arduino:avr:" + avrcik + ":cpu=atmega328 -build-path " + Evrensel + "\tempburaya -warnings=none -prefs=build.warn_data_percentage=75 -prefs=runtime.tools.avr-gcc.path=" + Evrensel + "\hardware\tools\avr -prefs=runtime.tools.avrdude.path=" + Evrensel + "\hardware\tools\avr -prefs=runtime.tools.arduinoOTA.path=" + Evrensel + "\hardware\tools\avr -verbose " + TempYolu + "\ArduAhmetTemp.ino"


                            'AVRDUDE İLE UPLOAD
                            ' Dim inoyolu As String = "C:\ArduAhmetTemp\ArduAhmetTemp.ino"
                            '  Dim komutYeni As String = ARDUYOL + "\arduino --board arduino:avr:" + tahta + " --port " + SecilenPort + " --upload " + inoyolu
                            '  Dim komutYeni As String = ARDUYOL + "\arduino --board arduino:avr:" + tahta + " --port " + SecilenPort + " --upload " + inoyolu

                            'BİTİR 


                            Shell("cmd.exe /c " + AhmetSon)
                            Threading.Thread.Sleep(1000)
                            ProgressBar1.Visible = True
                            ProgressBar1.Value = 55
                            log.Text += "Karta yükleme işlemleri başlıyor! 18" + vbNewLine
                            durum.Text = "Karta yükleme işlemleri başlıyor!"
                            Alt1.BackColor = Color.CornflowerBlue
                            log.ForeColor = Color.White

                            Shell("cmd.exe /c " + AhmetSon2)
                            log.Text += "Karta yükleme işlemleri için son kontroller yapılıyor! 19" + vbNewLine
                            durum.Text = "Karta yükleme işlemleri için son kontroller yapılıyor!"
                            Alt1.BackColor = Color.CornflowerBlue
                            log.ForeColor = Color.White

                            ProgressBar1.Value = 65
process_bitsin_bekle:

                            Threading.Thread.Sleep(1000)

                            For Each item In Process.GetProcesses
                                If (item.ProcessName.ToString() = "cmd") Then
                                    GoTo process_bitsin_bekle
                                End If
                            Next

                            For Each item In Process.GetProcesses
                                If (item.ProcessName.ToString() = "cmd") Then
                                    item.Kill()
                                End If
                            Next

                            Threading.Thread.Sleep(500)
                            Uploadtimer.Enabled = True

                        End If







                        HexTamYol = "yok"


                    Else
                        My.Computer.FileSystem.CreateDirectory(TempYolu)
                        GoTo furkan




                    End If







                    'temp dosya bitiş


                End If
            End If
        Catch ex As Exception

        End Try
        'End If
    End Sub

    Private Sub KütüphaneEkleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KütüphaneEkleToolStripMenuItem.Click
        MessageBox.Show(" ")
    End Sub

    Private Sub log_TextChanged(sender As Object, e As EventArgs) Handles log.TextChanged
        log.SelectionStart = log.Text.Length
        log.ScrollToCaret()
    End Sub

    'Sub r(ByVal halledilecek As String, ByVal renkcik As Color, ByVal ozellik As Boolean)
    '    Try

    '        Dim eskiyer As Integer = Poortextbox1_yedek.SelectionStart
    '        Dim pStr As String = halledilecek


    '        Dim pColor As Drawing.Color = renkcik



    '        Dim i As Integer
    '        Dim posAnt As Integer

    '        posAnt = -1

    '        Poortextbox1.SelectionStart = 0
    '        Poortextbox1.SelectionLength = 0
    '        Poortextbox1_yedek.DeselectAll()

    '        For i = 0 To 100

    '            If i = 0 Then

    '                Poortextbox1_yedek.Find(pStr, 0, RichTextBoxFinds.WholeWord)
    '            Else
    '                Poortextbox1_yedek.Find(pStr, Poortextbox1_yedek.SelectionStart + 1, RichTextBoxFinds.WholeWord)
    '            End If

    '            If posAnt = Poortextbox1_yedek.SelectionStart Then
    '                Exit For
    '            End If
    '            If (ozellik = True) Then
    '                Poortextbox1_yedek.SelectionFont = New Font("Microsoft Sans Serif", 15, FontStyle.Bold)
    '                Poortextbox1_yedek.SelectionColor = pColor
    '                posAnt = Poortextbox1_yedek.SelectionStart
    '            Else
    '                Poortextbox1_yedek.SelectionColor = pColor
    '                posAnt = Poortextbox1_yedek.SelectionStart
    '            End If



    '        Next
    '        Poortextbox1_yedek.Select(0, 0)
    '        Poortextbox1_yedek.DeselectAll()

    '        Poortextbox1_yedek.SelectionStart = eskiyer
    '        Poortextbox1_yedek.SelectionColor = Color.Black
    '        Poortextbox1_yedek.DeselectAll()
    '    Catch ex As Exception

    '    End Try

    'End Sub
    'Private Sub Renklendir()
    '    'r("{", Color.FromArgb(255, 94, 109, 3), 0)
    '    'r("}", Color.FromArgb(255, 94, 109, 3), 0)


    '    r("=", Color.Orange, 0)
    '    r("<", Color.Orange, 0)
    '    r(">", Color.Orange, 0)
    '    r("!", Color.Orange, 0)
    '    r("?", Color.Orange, 0)
    '    r("+", Color.Orange, 0)
    '    r("-", Color.Orange, 0)
    '    r(":", Color.Orange, 0)
    '    r("^", Color.Orange, 0)
    '    r("~", Color.Orange, 0)


    '    'mavinin özel tonu Color.FromArgb(255, 102, 221, 255)
    '    r("fonksiyon", Color.MidnightBlue, 0)

    '    r("ayarlar", Color.CornflowerBlue, 0) 'Color.FromArgb(255, 94, 109, 3)
    '    r("tekrarlar", Color.CornflowerBlue, 0)
    '    r("döngü", Color.CornflowerBlue, 0)


    '    r("yaz", Color.Orange, 0)
    '    r("analogoku", Color.Orange, 0)
    '    r("dijitaloku", Color.Orange, 0)
    '    r("pindurumu", Color.Orange, 0)
    '    r("bekle", Color.Orange, 0)

    '    r("giriş", Color.FromArgb(255, 102, 221, 255), 0) 'Color.FromArgb(255, 102, 221, 255)

    '    r("çıkış", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("yak", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("söndür", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("aktif", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("pasif", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("doğru", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("yanlış", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("giriş_pullup", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("gömülü_led", Color.FromArgb(255, 102, 221, 255), 0)
    '    r("KARTTAKİ_LED", Color.FromArgb(255, 102, 221, 255), 0)




    '    r("gönder", Color.Orange, 0)
    '    r("başlat", Color.Orange, 0)
    '    r("gönderasg", Color.Orange, 0)
    '    r("hazırsa", Color.Orange, 0)
    '    r("bitir", Color.Orange, 0)
    '    r("oku", Color.Orange, 0)
    '    r("iletişim", Color.Orange, 0)


    '    r("eğer", Color.FromArgb(255, 94, 109, 3), 0)
    '    r("ya da ", Color.FromArgb(255, 94, 109, 3), 0)

    '    r("aksi", Color.FromArgb(255, 94, 109, 3), 0)
    '    r("değilse", Color.FromArgb(255, 94, 109, 3), 0)
    '    r("aksi halde", Color.FromArgb(255, 94, 109, 3), 0)

    '    r("reel sayı", Color.Purple, 0)
    '    r("tam sayı", Color.Purple, 0)
    '    r("kelime", Color.Purple, 0)
    '    r("karakter", Color.Purple, 0)
    '    r("bayt", Color.Purple, 0)
    '    r("mantıksal", Color.Purple, 0)
    '    r("dizi", Color.Purple, 0)
    '    r("pozitif tam sayı", Color.Purple, 0)
    '    r("pozitif karakter", Color.Purple, 0)
    '    r("//", Color.Gray, 1) ' buun için kod yaz kardeş

    'End Sub


    Private Sub hallet(ByVal bulunacak As String, ByVal renkcik As Color)
        Poortextbox1_yedek.Find(bulunacak)
        Poortextbox1_yedek.SelectionColor = renkcik
        Poortextbox1_yedek.Select(0, 0)
        Dim eskiyer As Integer = Poortextbox1_yedek.SelectionStart
        Poortextbox1_yedek.SelectionStart = eskiyer
        Poortextbox1_yedek.SelectionColor = Color.Black
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        DoğrulaDerleToolStripMenuItem.PerformClick()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ' DoğrulaDerleToolStripMenuItem.PerformClick()
        TamDerle()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
    End Sub

    Private Sub PortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PortToolStripMenuItem.Click

    End Sub

    Private Sub AraçlarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AraçlarToolStripMenuItem.Click
        Try
            PortToolStripMenuItem.DropDownItems.Clear()

            Dim portlar As String() = SerialPort.GetPortNames()
            For Each portcuk In portlar
                Dim yeni As ToolStripMenuItem = New ToolStripMenuItem(portcuk)
                PortToolStripMenuItem.DropDownItems.Add(yeni)
                AddHandler yeni.Click, AddressOf portsec
            Next
        Catch ex As Exception
            log.Text += ex.Message
        End Try
    End Sub

    Private Sub AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AToolStripMenuItem.Click
        Dim cikti As String = "C:\inoET\Compile\cikti"
        My.Computer.FileSystem.DeleteDirectory(cikti, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        My.Computer.FileSystem.CreateDirectory(cikti)
    End Sub

    Private Sub KomutlarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KomutlarToolStripMenuItem.Click
        '  MessageBox.Show(Label3.Text)
        Try
            Process.Start(Application.StartupPath.ToString + "\Komutlar_Final_Yarim.txt")
        Catch ex As Exception
            log.Text += ex.Message + vbNewLine
        End Try
    End Sub

    Private Sub GözKırpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GözKırpToolStripMenuItem.Click
        Poortextbox1_yedek.Clear()
        Poortextbox1_yedek.Text = "Fonksiyon Ayarlar(){" + " " + vbNewLine + "}" + vbNewLine + "Fonksiyon Tekrarlar(){" + vbNewLine + "Yaz(13,Aktif);" + vbNewLine + "Bekle(1000);" + vbNewLine + "Yaz(13,Pasif);" + vbNewLine + "Bekle(1000);" + vbNewLine + "}"
        BestTextBox.Text = Poortextbox1_yedek.Text
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub DerleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DerleToolStripMenuItem.Click
        Poortextbox1_yedek.Enabled = False
        BestTextBox.Enabled = False
        ListBox3.Items.Clear()
        log.Text = ""
        ProgressBar1.Value = 0
        Derle()
        System.Threading.Thread.Sleep(1000)
        Derle()
        Poortextbox1_yedek.Enabled = True
        BestTextBox.Enabled = True
    End Sub

    Private Sub DerleBox_Click(sender As Object, e As EventArgs) Handles DerleBox.Click
        TamDerle()
    End Sub
    Dim tamderle_cikis As Boolean = False
    Sub TamDerle()
        BestTextBox.Enabled = False
        Poortextbox1_yedek.Enabled = False
        ListBox3.Items.Clear()
        log.Text = ""
        ProgressBar1.Value = 0
        Derle()
        System.Threading.Thread.Sleep(1000)
        Derle()
        Poortextbox1_yedek.Enabled = True
        BestTextBox.Enabled = True
        ' MessageBox.Show("Derleme işlemi sona erdi.")

        If tamderle_cikis = True Then
            KaydetToolStripMenuItem.PerformClick()
            Yukle()
        Else
            durum.Text = "Bir hata meydana geldi! 3 "
        End If


    End Sub

    Function Kelime(kel As String) ' Kelimenin geçtiği satırı verir.
        Poortextbox1_yedek.Text = BestTextBox.Text
        Dim b As Integer = 0
        Dim istenen As Integer
        While (b < Poortextbox1_yedek.Lines.Length)
            If (Poortextbox1_yedek.Lines(b).ToLower.Contains(kel)) Then
                istenen = b
                Exit While
            End If
            b += 1
        End While
        Return istenen
    End Function

    Sub Ekle(kel As String, ist As String) ' kel kelimesinin geçtiği satırın altına ist öğesini ekler
        Poortextbox1_yedek.Text = BestTextBox.Text
        Dim k As String = Poortextbox1_yedek.Lines(Kelime(kel))
        Poortextbox1_yedek.Find(k)
        Poortextbox1_yedek.SelectedText = k + vbNewLine + ist
    End Sub
    'Sub Degis(ist As String, satir As Integer, rtb As RichTextBox) ' satir numaralı satirın altına ist ekle
    '    Dim k As String = rtb.Lines(satir)
    '    rtb.Find(k)
    '    rtb.SelectedText = ist
    'End Sub

    Private Sub YardımToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YardımToolStripMenuItem.Click

    End Sub

    Private Sub un_Tick(sender As Object, e As EventArgs)


    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub DosyaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DosyaToolStripMenuItem.Click


    End Sub

    Private Sub ArduinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArduinoToolStripMenuItem.Click
        tahtasec = "uno"
        karttool.Text = "ARDUINO UNO"
    End Sub

    Private Sub NanoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NanoToolStripMenuItem.Click
        tahtasec = "nano"
        karttool.Text = "ARDUINO NANO"
    End Sub

    Private Sub LeonardoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeonardoToolStripMenuItem.Click
        tahtasec = "leonardo"
        karttool.Text = "ARDUINO LEONARDO"
    End Sub

    Private Sub Ust1_Paint(sender As Object, e As PaintEventArgs) Handles Ust1.Paint

    End Sub

    Private Sub UploadTakip_Tick(sender As Object, e As EventArgs) Handles UploadTakip.Tick



        'if  javaw.exe open bir şey yapma
        'else yap  

        If (Process.GetProcessesByName("javaw").Length <> 0) Then

        Else
            UploadTakip.Enabled = False

            log.Text += vbNewLine + "Arduino'ya başarıyla yüklendi! 4"
        End If
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)

    End Sub


    Private Sub Serial_Click(sender As Object, e As EventArgs) Handles Serial.Click
        If SecilenPort = "" Then
            MessageBox.Show("Lütfen Port Seçiniz")
        Else
            SerialEkran.Text = "Seri İletişim Penceresi " + SecilenPort
            SerialEkran.Show()
        End If
    End Sub

    Private Sub serialkontrol_Tick(sender As Object, e As EventArgs) Handles serialkontrol.Tick
        If Application.OpenForms().OfType(Of SerialEkran).Any Then
            Serialbilgi.Text = "açık"
        Else
            Serialbilgi.Text = "kapalı"
        End If
    End Sub

    Private Sub SeriPortEkranıToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeriPortEkranıToolStripMenuItem.Click
        If SecilenPort = "" Then
            MessageBox.Show("Lütfen Port Seçiniz")
        Else
            SerialEkran.Text = "Seri İletişim Penceresi " + SecilenPort
            SerialEkran.Show()
        End If
    End Sub



    Dim cursor_satir As Integer

    Sub SenseEkle(ByVal liste As ArrayList)
        For Each itemcik In liste
            If (itemcik.ToString.ToLower.Contains(anahtar.ToLower)) Then
                sense.Items.Add(itemcik)
            End If

        Next
    End Sub




    'TAM SAYI FONKSİYON
    'MANTIKSAL FONKSİYON
    ' GİBİ TÜRLER İÇİN kontrol yap ve ekle

    'UPDATE




    Private popupMenu As AutocompleteMenu
    Private gecici_degiskenler As New ArrayList()
    Private keywords2 As New ArrayList()
    '  Private keywords As String() = {"Döndür", "ÇIKIŞ", "GİRİŞ", "GİRİŞ_PULLUP", "AKTİF", "PASİF", "SÖNDÜR", "YAK", "DOĞRU", "YANLIŞ", "GÖMÜLÜ_LED", "KARTTAKİ_LED", "Dizi", "Mantıksal", "Bayt", "Karakter", "Reel Sayı", "Tam Sayı", "Kelime", "Pozitif Tam Sayı", "Pozitif Karakter"}
    Private tanimlama_keywords As New ArrayList()
    Private methods As String() = {"Hazırsa()", "Bitir();", "Oku();", "Başlat();", "GönderASG();", "Gönder();"}
    Private snippets As String() = {"İletişim.^", "Bekle(^Süre);", "DijitalOku(^Pin);", "AnalogOku(^Pin);", "PinDurumu(^Pin,ÇIKIŞ);", "PinDurumu(^Pin,GİRİŞ);", "Yaz(^Pin,AKTİF);", "Yaz(^Pin,PASİF);", "Yaz(^Pin,Değer);", "Eğer(^Şart)" + vbNewLine + "{" + vbNewLine + "Komut;" + vbNewLine + "}", "Eğer(^Şart)" + vbNewLine + "{" + vbNewLine + "Komut;" + vbNewLine + "}" + vbNewLine + "Aksi Halde" + vbNewLine + "{" + vbNewLine + "Komut;" + vbNewLine + "}", "Eğer(^Şart)" + vbNewLine + "{" + vbNewLine + "Komut;" + vbNewLine + "}" + vbNewLine + "Ya da (Şart)" + vbNewLine + "{" + vbNewLine + "Komut;" + vbNewLine + "}" + vbNewLine + "Aksi  Halde" + vbNewLine + "{" + vbNewLine + "Komut;" + vbNewLine + "}"}
    Private declarationSnippets As String() = {"Fonksiyon ^FonksiyonAdı() {" & vbLf & vbLf & "}", "Tam Sayı Fonksiyon ^FonksiyonAdı() {" & vbLf & vbLf & "döndür 0;" + vbLf + "}", "Karakter Fonksiyon ^FonksiyonAdı() {" & vbLf & vbLf & "döndür 0;" + vbLf + "}", "Mantıksal Fonksiyon ^FonksiyonAdı() {" & vbLf & vbLf & "döndür 0;" + vbLf + "}", "Kelime Fonksiyon ^FonksiyonAdı() {" & vbLf & vbLf & "döndür ""kelimecik""; " + vbLf + "}", "Reel Sayı Fonksiyon ^FonksiyonAdı() {" & vbLf & vbLf & "döndür 0;" + vbLf + "}", "Döngü (^) {" & vbLf & "}", "Döngü (^;;) {" & vbLf & "}"}

    Public Sub New()
        keywords2.Add("Döndür")
        keywords2.Add("ÇIKIŞ")
        keywords2.Add("GİRİŞ")
        keywords2.Add("GİRİŞ_PULLUP")
        keywords2.Add("AKTİF")
        keywords2.Add("PASİF")
        keywords2.Add("SÖNDÜR")
        keywords2.Add("YAK")
        keywords2.Add("DOĞRU")
        keywords2.Add("YANLIŞ")
        keywords2.Add("GÖMÜLÜ_LED")
        keywords2.Add("KARTTAKİ_LED")
        keywords2.Add("Dizi")
        keywords2.Add("Mantıksal")
        keywords2.Add("Bayt")
        keywords2.Add("Karakter")
        keywords2.Add("Reel Sayı")
        keywords2.Add("Tam Sayı")
        keywords2.Add("Kelime")
        keywords2.Add("Pozitif Tam Sayı")
        keywords2.Add("Pozitif Karakter")
        keywords2.Add("Değişken")

        tanimlama_keywords.Add("Dizi")
        tanimlama_keywords.Add("Mantıksal")
        tanimlama_keywords.Add("Bayt")
        tanimlama_keywords.Add("Karakter")
        tanimlama_keywords.Add("Reel Sayı")
        tanimlama_keywords.Add("Tam Sayı")
        tanimlama_keywords.Add("Tam Sayı")
        tanimlama_keywords.Add("Kelime")
        tanimlama_keywords.Add("Pozitif Tam Sayı")
        tanimlama_keywords.Add("Pozitif Karakter")

        InitializeComponent()

        'create autocomplete popup menu
        popupMenu = New AutocompleteMenu(BestTextBox)
        'popupMenu2 = New AutocompleteMenu(BestTextBox)


        popupMenu.SearchPattern = "[\w\.:=!<>]"
        'popupMenu2.SearchPattern = "[\w\.:=!<>]"
        '
        BuildAutocompleteMenu()

    End Sub

    Private Sub BuildAutocompleteMenu()

        Dim items As New List(Of AutocompleteItem)()


        For Each item As String In snippets
            items.Add(New SnippetAutocompleteItem(item) With {.ImageIndex = 1})
        Next
        For Each item As String In declarationSnippets
            items.Add(New DeclarationSnippet(item) With {.ImageIndex = 0})
        Next
        For Each item As String In methods
            items.Add(New MethodAutocompleteItem(item) With {.ImageIndex = 2})
        Next

        For Each item As String In keywords2
            items.Add(New AutocompleteItem(item))
        Next



        items.Add(New InsertSpaceSnippet())
        items.Add(New InsertSpaceSnippet("^(\w+)([=<>!:]+)(\w+)$"))
        items.Add(New InsertEnterSnippet())

        'set as autocomplete source
        Try
            popupMenu.Items.SetAutocompleteItems(items)
        Catch ex As Exception

        End Try
        'popupMenu2.Items.SetAutocompleteItems(items2)
    End Sub

    ''' <summary>
    ''' This item appears when any part of snippet text is typed
    ''' </summary>
    Private Class DeclarationSnippet
        Inherits SnippetAutocompleteItem
        Public Sub New(ByVal snippet As String)
            MyBase.New(snippet)
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim pattern = Regex.Escape(fragmentText)
            If Regex.IsMatch(Text, "\b" & pattern, RegexOptions.IgnoreCase) Then
                Return CompareResult.Visible
            End If
            Return CompareResult.Hidden
        End Function
    End Class

    ''' <summary>
    ''' Divides numbers and words: "123AND456" -> "123 AND 456"
    ''' Or "i=2" -> "i = 2"
    ''' </summary>
    Private Class InsertSpaceSnippet
        Inherits AutocompleteItem
        Private pattern As String

        Public Sub New(ByVal pattern As String)
            MyBase.New("")
            Me.pattern = pattern
        End Sub


        Public Sub New()
            Me.New("^(\d+)([a-zA-Z_]+)(\d*)$")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            If Regex.IsMatch(fragmentText, pattern) Then
                Text = InsertSpaces(fragmentText)
                If Text <> fragmentText Then
                    Return CompareResult.Visible
                End If
            End If
            Return CompareResult.Hidden
        End Function

        Public Function InsertSpaces(ByVal fragment As String) As String
            Dim m = Regex.Match(fragment, pattern)
            If m Is Nothing Then
                Return fragment
            End If
            If m.Groups(1).Value = "" AndAlso m.Groups(3).Value = "" Then
                Return fragment
            End If
            Return (m.Groups(1).Value & " " & m.Groups(2).Value & " " & m.Groups(3).Value).Trim()
        End Function

        Public Overrides Property ToolTipTitle() As String
            Get
                Return Text
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Inerts line break after '}'
    ''' </summary>
    Private Class InsertEnterSnippet
        Inherits AutocompleteItem
        Private enterPlace As Place = Place.Empty

        Public Sub New()
            MyBase.New("[Alt Satıra Geç]")
        End Sub

        Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
            Dim r = Parent.Fragment.Clone()
            While r.Start.iChar > 0
                If r.CharBeforeStart = "}"c Then
                    enterPlace = r.Start
                    Return CompareResult.Visible
                End If

                r.GoLeftThroughFolded()
            End While

            Return CompareResult.Hidden
        End Function

        Public Overrides Function GetTextForReplace() As String
            'extend range
            Dim r As Range = Parent.Fragment
            Dim [end] As Place = r.[End]
            r.Start = enterPlace
            r.[End] = r.[End]
            'insert line break
            Return Environment.NewLine + r.Text
        End Function

        Public Overrides Sub OnSelected(ByVal popupMenu As AutocompleteMenu, ByVal e As SelectedEventArgs)
            MyBase.OnSelected(popupMenu, e)
            If Parent.Fragment.tb.AutoIndent Then
                Parent.Fragment.tb.DoAutoIndent()
            End If
        End Sub

        Public Overrides Property ToolTipTitle() As String
            Get
                Return "'}' Dan sonra satır ekle"
            End Get
            Set(ByVal value As String)
            End Set
        End Property
    End Class

    Dim eski_sayi As Integer = keywords2.Count

    Private ReferansEkle As TextStyle = New TextStyle(Brushes.Green, Nothing, FontStyle.Regular)
    Private YorumSatırı As TextStyle = New TextStyle(Brushes.Gray, Nothing, FontStyle.Regular)
    Private FonksiyonAd As Style = New TextStyle(Brushes.CornflowerBlue, Nothing, FontStyle.Regular)
    Private Fonksiyonn As Style = New TextStyle(Brushes.DarkBlue, Nothing, FontStyle.Regular)
    Private Kontrol As Style = New TextStyle(Brushes.CornflowerBlue, Nothing, FontStyle.Regular)
    Private IOlar As Style = New TextStyle(Brushes.DarkBlue, Nothing, FontStyle.Regular)
    Private AnaKomutlar As Style = New TextStyle(Brushes.Orange, Nothing, FontStyle.Regular)
    Private Tanımlamalar As Style = New TextStyle(Brushes.DarkBlue, Nothing, FontStyle.Regular)
    Private DEGISKEN As Style = New TextStyle(Brushes.Red, Nothing, FontStyle.Regular)
    Private İletişim As Style = New TextStyle(Brushes.Orange, Nothing, FontStyle.Bold)
    Private İletişimKomutları As Style = New TextStyle(Brushes.Orange, Nothing, FontStyle.Regular)

    'KAFAN KARISMASIN DİYE SÖYLÜYORUM
    'HIGHLIGHT YAPARKEN IGNORE CASE DIYEBİLİRSİN ÇÜNKÜ ZATEN DERLENİRKEN HEPSİ LOWER OLARAK DERLENECEK
    'FAKAT AUTOCOMPLETE YA DA INTELLISENSE YAPARKEN BUNU DİYEMEZSİN ÇÜNKÜ AUTO COMPL MENÜSÜNDE İ ve i değişik,çok ta önemi yok..
    'adam giriş yazdığında da doğru GİRİŞ yazdığında da,fakat resmi olarak GİRİŞ
    Private Sub degislan(sender As Object, e As TextChangedEventArgs) Handles BestTextBox.TextChanged
        ' e.ChangedRange.ClearStyle(New Style() {Me.YorumSatırı})
        ' e.ChangedRange.SetStyle(Me.YorumSatırı, "//[^>]+") ' YORUM SATIRI
        e.ChangedRange.ClearStyle(New Style() {Me.ReferansEkle})
        e.ChangedRange.SetStyle(Me.ReferansEkle, "#[^\n]+") ' Referans için, \n bu bitirme trigi
        CType(sender, FastColoredTextBox).Range.ClearStyle(New Style() {Me.İletişimKomutları, Me.İletişim, Me.Kontrol, Me.DEGISKEN, Me.FonksiyonAd, Me.IOlar, Me.Fonksiyonn, Me.Tanımlamalar, Me.AnaKomutlar}) ' Temizle
        CType(sender, FastColoredTextBox).Range.SetStyle(Me.Kontrol, "\b(değilse|eğer|aksi halde|ya da)\b", RegexOptions.IgnoreCase) ' Uygula
        CType(sender, FastColoredTextBox).Range.SetStyle(Me.IOlar, "\b(DÖNDÜR|döndür|Döndür|DOĞRU|YANLIŞ|GÖMÜLÜ_LED|KARTTAKİ_LED|ÇIKIŞ|GİRİŞ|GİRİŞ_PULLUP|AKTİF|PASİF|SÖNDÜR|YAK)\b", RegexOptions.IgnoreCase) ' Uygula
        CType(sender, FastColoredTextBox).Range.SetStyle(Me.Fonksiyonn, "\b(fonksiyon)\b", RegexOptions.IgnoreCase) ' Uygula
        CType(sender, FastColoredTextBox).Range.SetStyle(Me.Tanımlamalar, "\b(Dizi|Mantıksal|Bayt|Karakter|Reel Sayı|Tam Sayı|Kelime|Pozitif Tam Sayı|Pozitif Karakter|Değişken)\b", RegexOptions.IgnoreCase) ' Uygula
        CType(sender, FastColoredTextBox).Range.SetStyle(Me.AnaKomutlar, "\b(Yaz|PinDurumu|DijitalOku|AnalogOku|Bekle|Döngü)\b", RegexOptions.IgnoreCase) ' Uygula
        CType(sender, FastColoredTextBox).Range.SetStyle(Me.İletişim, "\b(iletişim)\b", RegexOptions.IgnoreCase) ' Uygula
        CType(sender, FastColoredTextBox).Range.SetStyle(Me.İletişimKomutları, "\b(başlat|gönder|gönderasg|hazırsa|bitir|oku)\b", RegexOptions.IgnoreCase) ' Uygula
        CType(sender, FastColoredTextBox).Range.SetStyle(Me.ReferansEkle, "\b(Referans|referans|REFERANS)\b", RegexOptions.IgnoreCase) ' Uygula

        For Each found As Range In CType(sender, FastColoredTextBox).GetRanges("\b(fonksiyon|FONKSİYON|Fonksiyon)\s+(?<range>\w+)\b")
            CType(sender, FastColoredTextBox).Range.SetStyle(Me.FonksiyonAd, "\b" + found.Text + "\b")
        Next
        For Each found As Range In CType(sender, FastColoredTextBox).GetRanges("\b(Dizi|Mantıksal|Bayt|Karakter|Reel Sayı|Tam Sayı|Kelime|Pozitif Tam Sayı|Pozitif Karakter|Değişken)\s+(?<range>\w+)\b", RegexOptions.IgnoreCase)
            CType(sender, FastColoredTextBox).Range.SetStyle(Me.DEGISKEN, "\b" + found.Text + "\b")
        Next

        e.ChangedRange.ClearFoldingMarkers()
        e.ChangedRange.SetFoldingMarkers("{", "}")

        'ListBox4.Items.Clear()

        'gecici_degiskenler.Clear()

        '' değişkenleri al
        'For Each satir In BestTextBox.Lines
        '    For Each tanimlamalar In tanimlama_keywords
        '        If (satir.Contains(tanimlamalar) And satir.Contains("=")) Then
        '            If ListBox4.Items.Contains(satir.Split("=")(0).Replace(tanimlamalar, "").Trim()) Then

        '            Else
        '                ListBox4.Items.Add(satir.Split("=")(0).Replace(tanimlamalar, "").Trim())
        '                gecici_degiskenler.Add(satir.Split("=")(0).Replace(tanimlamalar, "").Trim())

        '            End If
        '        End If
        '    Next
        'Next

        'For Each eklenecek In gecici_degiskenler
        '    If (keywords2.Contains(eklenecek)) Then
        '        'geç
        '    Else
        '        keywords2.AddRange(gecici_degiskenler)
        '    End If
        'Next

        'BuildAutocompleteMenu()

    End Sub

    Private Sub TercihlerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TercihlerToolStripMenuItem.Click
        'Ayarlar - Ardu Yolu

        Try
            MessageBox.Show("Lütfen Arduino.exe'yi seçiniz")
            OpenFileDialog1.ShowDialog()

            ARDUYOL = OpenFileDialog1.FileName.Replace("\arduino.exe", "")
            MessageBox.Show(ARDUYOL)
        Catch ex As Exception

        End Try



    End Sub

    Private Sub YazdırToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YazdırToolStripMenuItem.Click

    End Sub

    Private Sub ÇıkışToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÇıkışToolStripMenuItem.Click
        End
    End Sub

    Private Sub KapatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KapatToolStripMenuItem.Click

    End Sub

    Private Sub Uploadtimer_Tick(sender As Object, e As EventArgs) Handles Uploadtimer.Tick
tekrar_kontrol:

        If (Process.GetProcessesByName("cmd").Count > 0) Then ' Eğer cmd açıksa
            For Each item In Process.GetProcesses
                If (item.ProcessName.ToString() = "cmd") Then
                    item.Kill()
                End If
            Next
            GoTo tekrar_kontrol
        Else ' cemede kapalıysa
            Uploadtimer.Enabled = False
            ProgressBar1.Value = 75
            Dim iletisim_hizi As Integer = 57600 ' NANO
            'iletisim_hizi=57600 nano
            'iletisim_hizi=9600 unodur sanırım
            'NOT -F -V sonradan eklendi doğrulamayı ve diğer saçmalığı deaktifleştirmek için 

            Dim AhmetSon3 As String = Evrensel + "\hardware/tools/avr/bin/avrdude -C" + Evrensel + "/hardware/tools/avr/etc/avrdude.conf -v -v -v -v -patmega328p -carduino -P" + SecilenPort + " -b" + iletisim_hizi.ToString + " -D -Uflash:w:" + Evrensel + "\tempburaya\ArduAhmetTemp.ino.hex:i"
            Dim foruno As String = Evrensel + "\hardware/tools/avr/bin/avrdude -v -p atmega328p -c arduino -P " + SecilenPort + " -b 115200 -D -U flash:w:" + Evrensel + "\tempburaya\ArduAhmetTemp.ino.hex:i"


            If (tahtasec = "uno") Then
                iletisim_hizi = 9600
                Shell("cmd.exe /c " + foruno) ' AhmetSon3
                Shell("cmd.exe /c " + foruno)
            ElseIf (tahtasec = "nano") Then
                iletisim_hizi = 57600
                Shell("cmd.exe /c " + AhmetSon3) ' AhmetSon3
                Shell("cmd.exe /c " + AhmetSon3)
            Else
                MessageBox.Show("Kritik Hata! -1")
            End If


            Uploadtimer2.Enabled = True

            'System.Threading.Thread.Sleep(1000)
            'durum.Text = "Karta yükleme işlemi hatasız bir şekilde tamamlandı."
            'log.Text += "Karta yükleme işlemi hatasız bir şekilde tamamlandı. 5" + vbNewLine
            'Alt1.BackColor = Color.CornflowerBlue
            'log.ForeColor = Color.White
            'ProgressBar1.Value = 100
            'System.Threading.Thread.Sleep(500)
            'ProgressBar1.Visible = False


        End If
    End Sub

    Private Sub Uploadtimer2_Tick(sender As Object, e As EventArgs) Handles Uploadtimer2.Tick
        If (Process.GetProcessesByName("cmd").Count > 0) Then ' Eğer cmd açıksa

        Else ' cemede kapalıysa
            Uploadtimer2.Enabled = False
            durum.Text = "Karta yükleme işlemi hatasız bir şekilde tamamlandı."
            log.Text += "Karta yükleme işlemi hatasız bir şekilde tamamlandı. 5" + vbNewLine
            Alt1.BackColor = Color.CornflowerBlue
            log.ForeColor = Color.White
            ProgressBar1.Value = 100
            System.Threading.Thread.Sleep(500)
            ProgressBar1.Visible = False
        End If
    End Sub

    Dim eklenenler As New ArrayList
    Private Sub TRduinoReferansDosyasıEkleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TRduinoReferansDosyasıEkleToolStripMenuItem.Click



        Try
            OpenFileDialog1.Filter = "TRduino Referans Dosyası(*.trr)|*.trr|C Başlık Dosyası(*.h)|*.h|C Kod Dosyası(*.cpp)|*.cpp"

            If (OpenFileDialog1.ShowDialog = DialogResult.OK) Then
                'TAB 
                Dim Eklenen_Referans_Tab As New TabPage
                TabControl1.Controls.Add(Eklenen_Referans_Tab)
                Eklenen_Referans_Tab.Text = OpenFileDialog1.SafeFileName.ToString
                Eklenen_Referans_Tab.Tag = OpenFileDialog1.FileName
                'TABIN TEXTBOXU
                Dim Onunki As New FastColoredTextBox
                Onunki.Font = BestTextBox.Font
                Onunki.Name = OpenFileDialog1.SafeFileName
                Onunki.Dock = DockStyle.Fill
                Eklenen_Referans_Tab.Controls.Add(Onunki)

                'AYARLARI UYGULA
                AddHandler Onunki.TextChanged, AddressOf degislan
                AddHandler Onunki.KeyDown, AddressOf referanslar_icin
                popupMenu = New AutocompleteMenu(Onunki)


                'YAZIYI AL
                Dim Gecici_al As New RichTextBox
                Gecici_al.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
                Onunki.Text = Gecici_al.Text

                'OPSİYONEL
                Onunki.Text = Onunki.Text.Replace("void setup", "Fonksiyon Ayarlar").Replace("void loop", "Fonksiyon Tekrarlar").Replace("unsigned Char", "Pozitif Karakter").Replace("unsigned int", "Pozitif Tam Sayı").Replace("pinMode", "PinDurumu").Replace("OUTPUT", "ÇIKIŞ").Replace("INPUT", "GİRİŞ").Replace("delay", "Bekle").Replace("LOW", "PASİF").Replace("HIGH", "AKTİF").Replace("analogRead", "AnalogOku").Replace("digitalRead", "DijitalOku").Replace("Serial", "İletişim").Replace(".begin", ".Başlat").Replace(".available", ".Hazırsa").Replace("else if", "Ya da").Replace("else", "Aksi halde").Replace("if", "Eğer").Replace(".println", ".GönderASG").Replace(".print", ".Gönder").Replace(".read", ".Oku").Replace(".End", ".Bitir").Replace("True", "DOĞRU").Replace("False", "YANLIŞ").Replace("LED_BUILTIN", "GÖMÜLÜ_LED").Replace("int", "Tam Sayı").Replace("char", "Karakter").Replace("float", "Reel Sayı").Replace("array", "Dizi").Replace("boolean", "Mantıksal").Replace("byte", "Bayt").Replace("String", "Kelime").Replace("digitalWrite", "Yaz").Replace("analogWrite", "Yaz").Replace("void", "Fonksiyon").Replace("for", "Döngü").Replace("while", "Döngü").Replace("a0", "A0")



                'hallet:
                '                Try
                '                    'Referans Klasörüne Ekle ve işi bitir
                '                    If (System.IO.Directory.Exists("C:\TRduino\Referanslar")) Then
                '                        FileSystem.FileCopy(OpenFileDialog1.FileName, "C:\TRduino\Referanslar\" + OpenFileDialog1.SafeFileName)
                '                    Else
                '                        System.IO.Directory.CreateDirectory("C:\TRduino\Referanslar")
                '                        GoTo hallet
                '                    End If

                '                Catch ex As Exception
                '                    log.Text += "Bir hata meydana geldi1" + vbNewLine
                '                End Try



                'Referans dosyalarından .cpp ile bitenin içindeki bütün include'ları sil

                Try
                    If (Path.GetExtension(OpenFileDialog1.FileName) = ".cpp") Then
                        Dim dosyayolu As String = OpenFileDialog1.FileName


                        Dim cpp_dosyasi As String
                        cpp_dosyasi = My.Computer.FileSystem.ReadAllText(dosyayolu)


                        Dim sanal As New RichTextBox
                        sanal.Text = cpp_dosyasi

                        Dim k As Integer = 0
                        While (k < sanal.Lines.Length)

                            If (sanal.Lines(k).ToLower.Contains("include")) Then

                                sanal.Text = sanal.Text.Replace(sanal.Lines(k), "")

                            End If

                            k = k + 1
                        End While

                        My.Computer.FileSystem.WriteAllText(dosyayolu, sanal.Text, False)

                    End If
                Catch ex As Exception

                End Try

                'Raporla
                Try
                    If (eklenenler.Contains(OpenFileDialog1.FileName)) Then

                    Else
                        eklenenler.Add(OpenFileDialog1.FileName)
                        'LİNK VER 
                        'En başa git ve aynı zamanda besttextbox'a geçip yap :)
                        BestTextBox.SelectionStart = 0
                        BestTextBox.SelectionLength = 0
                        'En sona koyalım daha iyi :))
                        'BestTextBox.Text += vbNewLine
                        'BestTextBox.SelectionStart = BestTextBox.Text.Length
                        'BestTextBox.SelectionLength = 0
                        'Linki ata
                        BestTextBox.SelectedText = vbNewLine + "#Referans <" + OpenFileDialog1.FileName + ">" + vbNewLine

                    End If

                Catch ex As Exception
                    log.Text += "Bir hata meydana geldi2" + vbNewLine
                End Try




                'Raporla
                log.Text += OpenFileDialog1.SafeFileName + " Adlı referans dosyası başarıyla eklendi! 6" + vbNewLine






            Else

            End If

        Catch ex As Exception
            log.Text += "Bir Hata Meydana Geldi! 7 " + ex.Message + vbNewLine
        End Try
    End Sub


    Private Sub BloklarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BloklarToolStripMenuItem.Click
        Try
            Form2.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnUsteGit_Ve_Ekle(ByVal eklenecek As String)
        BestTextBox.SelectionStart = 0
        BestTextBox.SelectionLength = 0
        BestTextBox.SelectedText = eklenecek + vbNewLine
    End Sub

    Private Sub YorumSatırınaDönüştürToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YorumSatırınaDönüştürToolStripMenuItem.Click

    End Sub

    Private Sub BestTextBox_Load(sender As Object, e As EventArgs) Handles BestTextBox.Load

    End Sub

    Private Sub BestTextBox_SelectionChanged(sender As Object, e As EventArgs) Handles BestTextBox.SelectionChanged
        If BestTextBox.SelectedText.Length >= 1 Then
            ipucu.Text = "Değişken oluşturmak için CTRL+D kullanabilirsin!"
        Else
            ipucu.Text = ""
        End If
    End Sub
End Class
