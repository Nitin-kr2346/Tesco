using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tesco.Model
{
    public class CartItem
    {
        [JsonPropertyName("skuId")]
        virtual public int SkuId { get; set; }

        [JsonPropertyName("quantity")]
        virtual public int Quantity { get; set; }

        [NotMapped]
        virtual public float Total { get; set; }
    }
}
