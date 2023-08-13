namespace Server.Services;

using Models;

public static class GalleryService
{
    private static readonly List<Picture> pictures = new()
    {
        new Picture
        {
            ImageName = "Mountains",
            ImageUrl = "/assets/1.jpg",
            ArtistName = "Mosh Ben Ari",
            Description = "Mountains are the most prominent products of the immense forces which shape the living planet: tectonic drift, volcanic activity and erosion by wind, water, frost and precipitation. They are a source of minerals and ores, a habitat for unique plants and animals and are the source of all the world's major rivers, and they are home to many of the world's 1.1 billion poorest and most isolated people. The life-sustaining value of mountains make them a key priority for sustainable development.",
        },
        new Picture
        {
            ImageName = "View",
            ImageUrl = "/assets/2.jpg",
            ArtistName = "Ben Nevis",
            Description = "Amazing view is a picture of a beautiful landscape taken from a high angle. The picture is taken from a high angle, so the viewer can see the whole landscape. The picture is taken from a high angle, so the viewer can see the whole landscape. The picture is taken from a high angle, so the viewer can see the whole landscape.",
        },
        new Picture
        {
            ImageName = "Boat",
            ImageUrl = "/assets/3.jpg",
            ArtistName = "Noa Kadosh",
            Description = "A boat is a watercraft of a large range of types and sizes, but generally smaller than a ship, which is distinguished by its larger size, shape, cargo or passenger capacity, or its ability to carry boats. Small boats are typically found on inland waterways such as rivers and lakes, or in protected coastal areas. However, some boats, such as the whaleboat, were intended for use in an offshore environment. In modern naval terms, a boat is a vessel small enough to be carried aboard a ship. Anomalous definitions exist, as bulk freighters 1,000 feet (300 m) long on the Great Lakes are called oreboats. ",
        },
        new Picture
        {
            ImageName = "Pastoral",
            ImageUrl = "/assets/4.jpeg",
            ArtistName = "Gilad Shemesh",
            Description = "Pastoral is a picture of a beautiful landscape and a shepherd with his sheep. He is sitting on a rock and playing the flute. The sheep are grazing in the field. The shepherd is wearing a hat and a cloak. The sheep are white and black. The sky is blue and there are some clouds in the sky. The sun is shining and there are some trees in the background.",
        },
        new Picture
        {
            ImageName= "Cloudy",
            ImageUrl= "/assets/5.jpeg",
            ArtistName= "Ayala Tzur",
            Description = "Delve into the heart of an enchanting woodland, where ancient trees intertwine their branches to form a natural cathedral. Sunlight filters through the canopy, casting dappled shadows on the moss-covered ground.",
        },
        new Picture
        {
           ImageName= "Lake",
           ImageUrl= "/assets/6.jpeg",
           ArtistName= "Chana Yosef",
           Description = "Delve into the heart of an enchanting woodland, where ancient trees intertwine their branches to form a natural cathedral. Sunlight filters through the canopy, casting dappled shadows on the moss-covered ground.",
        },
        new Picture
        {
          ImageName= "Trees",
          ImageUrl= "/assets/7.jpeg",
          ArtistName= "Sefi Gabay",
          Description = "Delve into the heart of an enchanting woodland, where ancient trees intertwine their branches to form a natural cathedral. Sunlight filters through the canopy, casting dappled shadows on the moss-covered ground.",
        },
         new Picture
       {
          ImageName= "Sunset",
          ImageUrl= "/assets/8.jpg",
          ArtistName= "Elad Peretz",
          Description = "Delve into the heart of an enchanting woodland, where ancient trees intertwine their branches to form a natural cathedral. Sunlight filters through the canopy, casting dappled shadows on the moss-covered ground.",
       },
        new Picture
        {
            ImageName= "Flowery",
            ImageUrl= "/assets/9.jpg",
            ArtistName= "David Cohen",
            Description = "Delve into the heart of an enchanting woodland, where ancient trees intertwine their branches to form a natural cathedral. Sunlight filters through the canopy, casting dappled shadows on the moss-covered ground.",
        },
        new Picture
        {
            ImageName= "Sunrise",
            ImageUrl= "/assets/10.jpg",
            ArtistName= "Sara Nisim",
            Description = "Delve into the heart of an enchanting woodland, where ancient trees intertwine their branches to form a natural cathedral. Sunlight filters through the canopy, casting dappled shadows on the moss-covered ground.",
        },
        new Picture
        {
            ImageName= "Island",
            ImageUrl= "/assets/11.jpg",
            ArtistName= "Dan Levy",
            Description = "Delve into the heart of an enchanting woodland, where ancient trees intertwine their branches to form a natural cathedral. Sunlight filters through the canopy, casting dappled shadows on the moss-covered ground.",
        },
        new Picture
        {
            ImageName= "Sea",
            ImageUrl= "/assets/12.jpg",
            ArtistName= "Moshe Frid",
            Description = "Delve into the heart of an enchanting woodland, where ancient trees intertwine their branches to form a natural cathedral. Sunlight filters through the canopy, casting dappled shadows on the moss-covered ground.",
        }
    };

    public static List<Picture> GetPictures()
    {
        return pictures;
    }   
}