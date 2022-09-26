using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.ViewModels
{
    public class PixViewModel
    {
        public string IdCorrellacao { get; set; }
        
        public decimal Valor { get; set; }
        
        public string UrlQrCode { get; set; }

        public string ChavePix { get; set; }
    }
}