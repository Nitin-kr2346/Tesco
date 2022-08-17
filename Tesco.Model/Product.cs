using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Tesco.Model
{
    public class Product
    {
        [JsonPropertyName("skuId")]
        virtual public int SkuId { get; set; }

        [DisplayName("SKU Name")]
        [JsonPropertyName("skuName")]
        virtual public string SkuName { get; set; }

        [DisplayName("Name of the Product")]
        [JsonPropertyName("name")]
        virtual public string Name { get; set; }

        [DisplayName("Brand")]
        [JsonPropertyName("brand")]
        virtual public string Brand { get; set; }

        [DisplayName("Price of the Product")]
        [JsonPropertyName("price")]
        virtual public float Price { get; set; }

        [JsonPropertyName("offerQuantity")]
        virtual public int OfferQuantity { get; set; }

        [JsonPropertyName("offerPrice")]
        virtual public float OfferPrice { get; set; }

        [JsonPropertyName("offerExpiryDate")]
        virtual public DateTime OfferExpiryDate { get; set; }

        [DisplayName("Description")]
        [JsonPropertyName("description")]
        virtual public string Description { get; set; }
    }
}
