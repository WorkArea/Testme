using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Menu1
    {
        /// <summary>
        /// parent id of the parent
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// name of the menu
        /// </summary>
        [Required(ErrorMessage = "Please enter menu name")]
        [Display(Name ="Menu Name")]
        public string Name { get; set; }
        /// <summary>
        /// url of the menu
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// identify the menu status either enabled or disabled
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// content of the menu posted from editor
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// user id which has created this menu 
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>
        /// create date when usr has created this menu
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// user id which has last moifies this menu information
        /// </summary>
        public int ModifiedBy { get; set; }
        /// <summary>
        /// modified date when usr has modified this menu information
        /// </summary>
        public DateTime MpdofiedDate { get; set; }
    }
}