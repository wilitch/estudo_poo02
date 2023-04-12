using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProjetoAula02.Entities;

namespace ProjetoAula02.Repositories
{
    /// <summary>
    /// Classe para gravação dos dados do funcionário em arquivos
    /// </summary>
    public class FuncionarioRepository
    {
        /// <summary>
        /// Método para gravar os dados do funcionário em arquivo JSON
        /// </summary>
        public void ExportarJson(Funcionario funcionario)
        {
            var json = JsonConvert.SerializeObject(funcionario, Formatting.Indented);

            using (var streamWriter = new StreamWriter($"d:\\dev_coti\\funcionario_{funcionario.Id}.json"))
            {
                streamWriter.WriteLine(json);
            }
        }

        /// <summary>
        /// Método para gravar os dados do funcionário em arquivo XML
        /// </summary>
        public void ExportarXml(Funcionario funcionario)
        {
            var xml = new XmlSerializer(typeof(Funcionario));

            using (var streamWriter = new StreamWriter($"d:\\dev_coti\\funcionario_{funcionario.Id}.xml"))
            {
                xml.Serialize(streamWriter, funcionario);
            }
        }
    }
}
