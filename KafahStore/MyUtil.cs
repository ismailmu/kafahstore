using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;

namespace KafahStore
{
    public static class MyUtil
    {
        public const int MAX_FIELD_LENGTH = 255;
        public const string IMG_UPDATE = "[Ada Gambar]";
        private const string ALLOW_CHAR = @"[^0-9a-zA-Z\s&_]";

        public static string GetFormatNumber(string value)
        {
            Double valueRet;
            if (Double.TryParse(value, out valueRet))
            {
                return String.Format("{0:#,##0}", valueRet);
            }
            else
            {
                return String.Empty;
            }
        }

        public static string GetConnectionString()
        {
            return Properties.Settings.Default.KafahStoreDbConnectionString;
            //return String.Format(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\{0};Integrated Security=True;Connect Timeout=30", Properties.Settings.Default.db_path);
        }

        public static string SaveImage(string fullPathImage,string fileName,string type,string id = "0")
        {
            try
            {
                if (fullPathImage == String.Empty)
                {
                    return "";
                }

                if (fileName == String.Empty)
                {
                    return "";
                }

                if (fullPathImage == MyUtil.IMG_UPDATE)
                {
                    return MyUtil.IMG_UPDATE;
                }

                string maxId = "1";
                if (id == "0")
                {
                    string sql = "SELECT MAX(id) as max_id FROM m_barang";

                    maxId = ExecuteScalar(sql);
                    //access tidak bisa ISNULL dengan 0 (nol)
                    if (maxId == String.Empty)
                    {
                        maxId = "1";
                    }
                    else
                    {
                        maxId = (Int32.Parse(maxId) + 1).ToString();
                    }
                }
                else
                {
                    maxId = id;
                }

                string namaFile = Regex.Replace(fileName, @"\s+", " ", RegexOptions.Multiline);
                namaFile = namaFile.Replace(" ", "_");

                string ext = fullPathImage.Substring(fullPathImage.LastIndexOf('.'));

                string pathDest = String.Format(@"{0}\{1}", Properties.Settings.Default.image_path, maxId);

                if (!Directory.Exists(pathDest))
                    Directory.CreateDirectory(pathDest);

                File.Copy(fullPathImage, String.Format(@"{0}\{1}_{2}{3}", pathDest, type, namaFile, ext), true);

                return String.Format("{0}_{1}{2}", type, namaFile, ext);
            }
            catch (Exception ex)
            {
                return "";
                throw new Exception(ex.Message);
            }
        }

        public static void ExecuteNonQuery(string sql)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        comm.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ExecuteReader(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader rdr = comm.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dt.Load(rdr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }

        public static string ExecuteScalar(string sql)
        {
            string strRet=String.Empty;
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        object obj = comm.ExecuteScalar();
                        if (obj != null)
                        {
                            strRet = comm.ExecuteScalar().ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return strRet;
        }

        public static DataSet ExecuteReader(string sql,string datasetName,string tableName)
        {
            DataSet ds = new DataSet(datasetName);
            try
            {
                using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (OleDbCommand comm = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataAdapter adpt = new OleDbDataAdapter(comm))
                        {
                            adpt.Fill(ds, tableName);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds;
        }

        public static string AllowCharacter(string text,string replace)
        {
            return Regex.Replace(text, ALLOW_CHAR, replace, RegexOptions.Multiline);
        }
    }//end class
}//end namespace
