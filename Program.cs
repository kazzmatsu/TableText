using System;
using System.Data;
using System.Linq;
using System.Diagnostics;
 
namespace WindowsFormsApp28
{
    public partial class TableTest
    {
        static void Main ( string [] args )
        {
            var mmm = new TableTest();
            mmm.ClsMain();
        }
 
        internal void ClsMain()
        {
            var ds = new DataSet();
            var dt = new DataTable("Table0");
            var sw = new Stopwatch();
            // 列の追加
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("ランダム文字列", typeof(string));
            // DataSetにDataTableを追加
            ds.Tables.Add(dt);
             // 100万件データのサンプル
//            for (int i = 0; i < 10000000; i++)
            for (int i = 0; i < 100000; i++)
            {
                // ランダムな文字を生成します
                string s = Guid.NewGuid().ToString("N").Substring(0, 8);
                dt.Rows.Add(new object[] { i, s });
            }
             sw.Start();
            DataRow[] rowSearch = dt.AsEnumerable().Where(row => 100000 < row.Field<int>(0) && row.Field<int>(0) <= 900000).ToArray();
            sw.Stop();
            Console.WriteLine(@$"{rowSearch}");
            Console.WriteLine( @$"処理時間 : {sw.Elapsed.ToString()}");
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render(" Hello, World!"));
         }
    }
}