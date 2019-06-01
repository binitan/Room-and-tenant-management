using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp_RoomManagement.Classes
{
    internal class MyStorage
    {
        internal static T ReadXml<T>(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                    return (T)xmlSer.Deserialize(sr);

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x, "Caution ...");
                return default(T);
                throw;
            }
        }

        internal static void WriteXml<T>(T data, string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                FileStream stream;
                //stream = new FileStream(fileName, FileMode.Append,FileAccess.Write);
                stream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(stream, data);
                stream.Close();
            }
            catch (Exception X)
            {
                Console.WriteLine(X);
                throw;
            }
        }
    }
}
