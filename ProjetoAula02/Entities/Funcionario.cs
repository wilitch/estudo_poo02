using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula02.Entities
{
    /// <summary>
    /// Classe de modelo de dados para a entidade Funcionário
    /// </summary>
    public class Funcionario
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private string _matricula;
        private DateTime _dataAdmissao;
        private Funcao _funcao;

        public Guid Id 
        { 
            get => _id; 
            set
            {
                if (value == Guid.Empty)
                    throw new ArgumentException("Por favor, informe um ID válido.");

                _id = value;
            }                
        }
        public string Nome 
        { 
            get => _nome; 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe o nome do funcionário.");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,100}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um nome válido.");

                _nome = value;
            }          
        }
        public string Cpf 
        { 
            get => _cpf; 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe o cpf do funcionário.");

                var regex = new Regex("^[0-9]{11}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe um cpf somente com 11 dígitos numéricos.");

                _cpf = value;
            }
        }
        public string Matricula 
        { 
            get => _matricula; 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor, informe a matrícula do funcionário.");

                var regex = new Regex("^[A-Z0-9]{6,10}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Por favor, informe uma matrícula válida.");

                _matricula = value;
            }
        }
        public DateTime DataAdmissao 
        { 
            get => _dataAdmissao; 
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("Por favor, informe a data de admissão do funcionário.");
                     
                _dataAdmissao = value;
            }
        }

        public Funcao Funcao { get => _funcao; set => _funcao = value; }
    }
}
