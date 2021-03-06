// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Foodworld.models
{
    [Table("mycart")]
    public partial class Mycart
    {
        [Key]
        [Column("cartid")]
        public int Cartid { get; set; }
        [Column("username")]
        [StringLength(20)]
        [Unicode(false)]
        public string Username { get; set; }
        [Column("itemid")]
        [StringLength(20)]
        [Unicode(false)]
        public string Itemid { get; set; }

        [ForeignKey(nameof(Itemid))]
        [InverseProperty(nameof(Menu.Mycarts))]
        public virtual Menu Item { get; set; }
        [ForeignKey(nameof(Username))]
        [InverseProperty(nameof(Register.Mycarts))]
        public virtual Register UsernameNavigation { get; set; }
    }
}