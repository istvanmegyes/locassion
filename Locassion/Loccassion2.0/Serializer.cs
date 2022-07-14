using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Loccassion2._0
{
    class Serializer
    {
        Stream stream;
        IFormatter formatter = new BinaryFormatter();

        public Serializer() { }

        public void Write(List<Floor> floors, string filename)
        {
            if (filename!="")
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(filename, FileMode.Create, FileAccess.Write);

                formatter.Serialize(stream, floors);
                stream.Close();
            }
        }

        public List<Floor> Read(string path)
        {
            if (path != "")
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                List<Floor> temp = (List<Floor>)formatter.Deserialize(stream);

                return temp;
            }
            return null;
        }
    }
}
