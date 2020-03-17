using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _2doParcial.Entidades
{
    public class LlamadasDetalle
    {
        [Key]
        public int LlamadasDetalleId { get; set; }
        public int LlamadaId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadasDetalle()
        {
            LlamadasDetalleId = 0;
            LlamadaId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }

        public LlamadasDetalle(string Problema, string Solucion)
        {
            this.Problema = Problema;
            this.Solucion = Solucion;
        }
    }
}
