using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace userComentarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        [HttpGet]
        public string Get(string user_name)
        {
            using (StreamReader r = new StreamReader(@"./Mock/mock.json"))
            {
                string json = r.ReadToEnd();

                List<CommentsModel> result = new List<CommentsModel>();
                List<CommentsModel> comments = JsonConvert.DeserializeObject<List<CommentsModel>>(json);

                foreach (CommentsModel comment in comments.Where(c => c.nome_usuario == user_name))
                {
                    result.Add(comment);
                }

                return JsonConvert.SerializeObject(result);
            }
        }
    }
}
