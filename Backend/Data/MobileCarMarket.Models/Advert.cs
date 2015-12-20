namespace MobileCarMarket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Advert
    {
        private ICollection<ImageData> imagesData;
        private ICollection<User> favouritedByUsers;
        private ICollection<Comment> comments;

        public Advert()
        {
            this.imagesData = new HashSet<ImageData>();
            this.favouritedByUsers = new HashSet<User>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsNew { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public ImageData FirstImageData { get; set; }

        public virtual ICollection<ImageData> ImagesData
        {
            get { return this.imagesData; }
            set { this.imagesData = value; }
        }

        public virtual ICollection<User> FavouritedByUsers
        {
            get { return this.favouritedByUsers; }
            set { this.favouritedByUsers = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
