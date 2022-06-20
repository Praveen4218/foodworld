﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foodworld.models
{
    [Table("menu")]
    public partial class Menu
    {
        public Menu()
        {
            Mycarts = new HashSet<Mycart>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("itemid")]
        [StringLength(20)]
        [Unicode(false)]
        public string Itemid { get; set; }
        [Column("itemname")]
        [StringLength(20)]
        [Unicode(false)]
        public string Itemname { get; set; }
        [Column("itemdesc")]
        [StringLength(50)]
        [Unicode(false)]
        public string Itemdesc { get; set; }
        [Column("price")]
        public int? Price { get; set; }
        [Column("images")]
        [StringLength(50)]
        [Unicode(false)]
        public string Images { get; set; }

        [InverseProperty(nameof(Mycart.Item))]
        public virtual ICollection<Mycart> Mycarts { get; set; }
        [InverseProperty(nameof(Order.Item))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}