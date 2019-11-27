using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;


namespace ListaDiretório
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string pat = "";
        //int cont = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            //string[] Arquivos;
            //define um array com valores booleanos
            //bool[] Seleciona;

            //Arquivos = new string[cont];
            //Seleciona = new bool[cont];
            //cria um objeto DataTable
            DataTable dt = new DataTable();
            //inclui duas colunas no datatable definindo o seu tipo como booleano e string
            dt.Columns.Add("X", typeof(bool));
            dt.Columns.Add("Arquivo", typeof(string));

            DirectoryInfo Dir = new DirectoryInfo(@pat);
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                listBox1.Items.Add(File.FullName);
                DataRow dr = dt.NewRow();
                dr["X"] = false;
                //dr["Arquivo"] = File.FullName.ToString();
                if (checkBox1.Checked == false)
                {
                    dr["Arquivo"] = File.Name.ToString();
                }
                if (checkBox1.Checked == true)
                {
                    dr["Arquivo"] = File.FullName.ToString();
                }
                dt.Rows.Add(dr);

            }
            
           
            
            
            
            //vincula os valores do datatable no DataGridView
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                listBox2.Items.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "True")
                    {

                        listBox2.Items.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }


                }

            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                listBox2.Items.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "True")
                    {

                        listBox2.Items.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }


                }

            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                listBox2.Items.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "True")
                    {

                        listBox2.Items.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }


                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            DataTable n = new DataTable();
            dataGridView1.DataSource = n;
            // diretorio raiz
            DirectoryInfo dir = new DirectoryInfo(@pat);

            // no raiz
            System.Windows.Forms.TreeNode noRaiz = new System.Windows.Forms.TreeNode(dir.FullName);

            // lista diretorios a partir do no raiz
            ListaDiretorios(dir, noRaiz);

            // adiciona os nos à TreeView
            treeView1.Nodes.Add(noRaiz);
        }
        // METODO RECURSIVO PARA LISTA DIRETORIOS E SUB-DIRETORIOS
        private void ListaDiretorios(DirectoryInfo diretorioPai, System.Windows.Forms.TreeNode noPai)
        {
            // para cada sub-diretorio 
            foreach (DirectoryInfo dir in diretorioPai.GetDirectories())
            {
                // adiciona diretorio ao no corrente
                noPai.Nodes.Add(dir.Name);



                //string[] Arquivos;
                //define um array com valores booleanos
                //bool[] Seleciona;

                //Arquivos = new string[cont];
                //Seleciona = new bool[cont];
                //cria um objeto DataTable
                /*DataTable dt = new DataTable();
                //inclui duas colunas no datatable definindo o seu tipo como booleano e string
                dt.Columns.Add("Seleciona", typeof(bool));
                dt.Columns.Add("Arquivo", typeof(string));

                DirectoryInfo Dir = new DirectoryInfo(@dir.FullName);
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = Dir.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo File in Files)
                {
                    listBox1.Items.Add(File.FullName);
                    DataRow dr = dt.NewRow();
                    dr["Seleciona"] = false;
                    //dr["Arquivo"] = File.FullName.ToString();
                    dr["Arquivo"] = File.Name.ToString();
                    dt.Rows.Add(dr);

                }*/

                //dataGridView1.DataSource = dt;
                listBox1.Items.Add(dir.FullName);
                listBox3.Items.Add(dir.FullName);
                //MessageBox.Show(dir.Name);



                // lista diretorios do diretorio corrente
                ListaDiretorios(dir, noPai.LastNode);
                
            }
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                listBox2.Items.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "True")
                    {

                        listBox2.Items.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    }


                }
               

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = "False";
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBox3.SelectedIndex;
            string Valor = listBox3.Items[i].ToString();
            //MessageBox.Show(Valor);
            //string[] Arquivos;
            //define um array com valores booleanos
            //bool[] Seleciona;

            //Arquivos = new string[cont];
            //Seleciona = new bool[cont];
            //cria um objeto DataTable
            DataTable dt = new DataTable();
            //inclui duas colunas no datatable definindo o seu tipo como booleano e string
            dt.Columns.Add("X", typeof(bool));
            dt.Columns.Add("Arquivo", typeof(string));

            DirectoryInfo Dir = new DirectoryInfo(@Valor);
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo File in Files)
            {
                listBox1.Items.Add(File.FullName);
                DataRow dr = dt.NewRow();
                dr["X"] = false;
                //dr["Arquivo"] = File.FullName.ToString();
                if (checkBox1.Checked == false)
                {
                    dr["Arquivo"] = File.Name.ToString();
                }
                if (checkBox1.Checked == true)
                {
                    dr["Arquivo"] = File.FullName.ToString();
                }
                dt.Rows.Add(dr);

            }

            
        





            //vincula os valores do datatable no DataGridView
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = listBox3.SelectedIndex;
            string Valor = listBox3.Items[i].ToString();
            System.Diagnostics.Process.Start(Valor + "/" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string folder = @pat + textBox1.Text; //nome do diretorio a ser criado

            //Se o diretório não existir...

            if (!Directory.Exists(folder))
            {

                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);

            }

            treeView1.Nodes.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            DataTable n = new DataTable();
            dataGridView1.DataSource = n;
            // diretorio raiz
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\TI\Desktop\CDR");

            // no raiz
            System.Windows.Forms.TreeNode noRaiz = new System.Windows.Forms.TreeNode(dir.FullName);

            // lista diretorios a partir do no raiz
            ListaDiretorios(dir, noRaiz);

            // adiciona os nos à TreeView
            treeView1.Nodes.Add(noRaiz);
            textBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                /*System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();*/
                pat = folderBrowserDialog1.SelectedPath;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int THUMB_SIZE = 256;
            Bitmap thumbnail = WindowsThumbnailProvider.GetThumbnail(
               @dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString(), THUMB_SIZE, 500, ThumbnailOptions.BiggerSizeOk);
            pictureBox1.Image = thumbnail;
           // thumbnail.Dispose();

            
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }
    }
    [Flags]
        public enum ThumbnailOptions
        {
            None = 0x00,
            BiggerSizeOk = 0x01,
            InMemoryOnly = 0x02,
            IconOnly = 0x04,
            ThumbnailOnly = 0x08,
            InCacheOnly = 0x10,
        }

    public class WindowsThumbnailProvider
    {
        private const string IShellItem2Guid = "7E9FB0D3-919F-4307-AB2E-9B1860310C93";

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int SHCreateItemFromParsingName(
            [MarshalAs(UnmanagedType.LPWStr)] string path,
            // The following parameter is not used - binding context.
            IntPtr pbc,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem shellItem);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr hObject);

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
        internal interface IShellItem
        {
            void BindToHandler(IntPtr pbc,
                [MarshalAs(UnmanagedType.LPStruct)]Guid bhid,
                [MarshalAs(UnmanagedType.LPStruct)]Guid riid,
                out IntPtr ppv);

            void GetParent(out IShellItem ppsi);
            void GetDisplayName(SIGDN sigdnName, out IntPtr ppszName);
            void GetAttributes(uint sfgaoMask, out uint psfgaoAttribs);
            void Compare(IShellItem psi, uint hint, out int piOrder);
        };

        internal enum SIGDN : uint
        {
            NORMALDISPLAY = 0,
            PARENTRELATIVEPARSING = 0x80018001,
            PARENTRELATIVEFORADDRESSBAR = 0x8001c001,
            DESKTOPABSOLUTEPARSING = 0x80028000,
            PARENTRELATIVEEDITING = 0x80031001,
            DESKTOPABSOLUTEEDITING = 0x8004c000,
            FILESYSPATH = 0x80058000,
            URL = 0x80068000
        }

        internal enum HResult
        {
            Ok = 0x0000,
            False = 0x0001,
            InvalidArguments = unchecked((int)0x80070057),
            OutOfMemory = unchecked((int)0x8007000E),
            NoInterface = unchecked((int)0x80004002),
            Fail = unchecked((int)0x80004005),
            ElementNotFound = unchecked((int)0x80070490),
            TypeElementNotFound = unchecked((int)0x8002802B),
            NoObject = unchecked((int)0x800401E5),
            Win32ErrorCanceled = 1223,
            Canceled = unchecked((int)0x800704C7),
            ResourceInUse = unchecked((int)0x800700AA),
            AccessDenied = unchecked((int)0x80030005)
        }

        [ComImportAttribute()]
        [GuidAttribute("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IShellItemImageFactory
        {
            [PreserveSig]
            HResult GetImage(
            [In, MarshalAs(UnmanagedType.Struct)] NativeSize size,
            [In] ThumbnailOptions flags,
            [Out] out IntPtr phbm);
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct NativeSize
        {
            private int width;
            private int height;

            public int Width { set { width = value; } }
            public int Height { set { height = value; } }
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct RGBQUAD
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }

        public static Bitmap GetThumbnail(string fileName, int width, int height, ThumbnailOptions options)
        {
            IntPtr hBitmap = GetHBitmap(Path.GetFullPath(fileName), width, height, options);

            try
            {
                // return a System.Drawing.Bitmap from the hBitmap
                return GetBitmapFromHBitmap(hBitmap);
            }
            finally
            {
                // delete HBitmap to avoid memory leaks
                DeleteObject(hBitmap);
            }
        }

        public static Bitmap GetBitmapFromHBitmap(IntPtr nativeHBitmap)
        {
            Bitmap bmp = Bitmap.FromHbitmap(nativeHBitmap);

            if (Bitmap.GetPixelFormatSize(bmp.PixelFormat) < 32)
                return bmp;

            return CreateAlphaBitmap(bmp, PixelFormat.Format32bppArgb);
        }

        public static Bitmap CreateAlphaBitmap(Bitmap srcBitmap, PixelFormat targetPixelFormat)
        {
            Bitmap result = new Bitmap(srcBitmap.Width, srcBitmap.Height, targetPixelFormat);

            Rectangle bmpBounds = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);

            BitmapData srcData = srcBitmap.LockBits(bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);

            bool isAlplaBitmap = false;

            try
            {
                for (int y = 0; y <= srcData.Height - 1; y++)
                {
                    for (int x = 0; x <= srcData.Width - 1; x++)
                    {
                        Color pixelColor = Color.FromArgb(
                            Marshal.ReadInt32(srcData.Scan0, (srcData.Stride * y) + (4 * x)));

                        if (pixelColor.A > 0 & pixelColor.A < 255)
                        {
                            isAlplaBitmap = true;
                        }

                        result.SetPixel(x, y, pixelColor);
                    }
                }
            }
            finally
            {
                srcBitmap.UnlockBits(srcData);
            }

            if (isAlplaBitmap)
            {
                return result;
            }
            else
            {
                return srcBitmap;
            }
        }

        private static IntPtr GetHBitmap(string fileName, int width, int height, ThumbnailOptions options)
        {
            IShellItem nativeShellItem;
            Guid shellItem2Guid = new Guid(IShellItem2Guid);
            int retCode = SHCreateItemFromParsingName(fileName, IntPtr.Zero, ref shellItem2Guid, out nativeShellItem);

            if (retCode != 0)
                throw Marshal.GetExceptionForHR(retCode);

            NativeSize nativeSize = new NativeSize();
            nativeSize.Width = width;
            nativeSize.Height = height;

            IntPtr hBitmap;
            HResult hr = ((IShellItemImageFactory)nativeShellItem).GetImage(nativeSize, options, out hBitmap);

            Marshal.ReleaseComObject(nativeShellItem);

            if (hr == HResult.Ok) return hBitmap;

            throw Marshal.GetExceptionForHR((int)hr);
        }
    }
}
