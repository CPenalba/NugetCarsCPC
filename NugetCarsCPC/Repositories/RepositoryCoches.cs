using NugetCarsCPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace NugetCarsCPC.Repositories
{
    public class RepositoryCoches
    {
        private XDocument document;

        public RepositoryCoches()
        {
            //PARA RECUPERAR UN RECURSO INCRUSTADO NECESITAMOS EL NAMESPACE Y, SI LO TUVIERA
            //LA CARPETA DONDE ESTUVIERA EL RECURSO INCRSUTADO
            string resourceName = "NugetCarsCPC.coches.xml";
            //LOS FICHEROS SE RECUPERAN MEDIANTE BYTES, ES DECIR MEDIANTE STREAM
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName);
            //COMO ES UN XML FISICO, SE UTILIZA EL METODO LOAD
            this.document = XDocument.Load(stream);
        }

        public List<Coche> GetCoches()
        {
            var consulta = from datos in this.document.Descendants("coche") select datos;
            List<Coche> cars = new List<Coche>();
            foreach (var tag in consulta)
            {
                Coche car = new Coche();
                car.IdCoche = int.Parse(tag.Element("idCoche").Value);
                car.Marca = tag.Element("marca").Value;
                car.Modelo = tag.Element("modelo").Value;
                car.Imagen = tag.Element("imagen").Value;
                cars.Add(car);
            }
            return cars;
        }
    }
}
