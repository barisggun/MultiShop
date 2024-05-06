using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //Benzersiz olduğunu bildirmek için
        public string Id { get; set; }
        public string CategoryName { get; set; }

    }
}
