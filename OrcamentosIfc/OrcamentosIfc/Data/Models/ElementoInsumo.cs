﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc.Data.Models
{
    public class ElementoInsumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ElementoId { get; set; }

        [Required]
        public string InsumoCodigo{ get; set; }

        [Required]
        public string Dimensao { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 6)")]
        public decimal Quantidade { get; set; }

        [NotMapped]
        public ElementoProjeto ElementoProjeto { get; set; }

        [NotMapped]
        public Insumo Insumo { get; set; }

        public void LoadInsumo()
        {
            Insumo = Parametros.AppDbContext.Insumos.FirstOrDefault(i => i.Codigo == InsumoCodigo
                                                                                && i.Prefixo == Parametros.PeriodoSinapiSelecionado);
        }
    }
}
