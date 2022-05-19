using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;

namespace userComentarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        [EnableCors("AllowSpecificOrigin")]
        [HttpGet("{user_name}")]
        public string Get(string user_name)
        {
            using (StreamReader r = new StreamReader(@"./Mock/mock.json"))
            {
                string conteudo_mock = r.ReadToEnd();

                List<CommentsModel> result = new List<CommentsModel>();
                List<CommentsModel> comments = JsonConvert.DeserializeObject<List<CommentsModel>>(conteudo_mock);

                foreach (CommentsModel comment in comments.Where(c => c.nome_usuario == user_name))
                {
                    result.Add(comment); 
                }

                return JsonConvert.SerializeObject(result);
            }
        }
    }
}
