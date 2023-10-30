using TaskVectoDigital.Models;

namespace TaskVectoDigital.Models
{
  
        public class ImageResponseModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public List<Effect> Effects { get; set; }
        }
   
}
