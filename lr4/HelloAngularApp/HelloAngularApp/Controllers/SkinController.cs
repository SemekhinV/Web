using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HelloAngularApp.Models;

namespace HelloAngularApp.Controllers
{
    [ApiController]
    [Route("api/skins")]
    public class SkinController : Controller
    {
        ApplicationContext db;
        public SkinController(ApplicationContext context)
        {
            db = context;
            
            if (!db.Skins.Any())
            {
                db.Skins.Add(new Skin { SkinName = "CoolBoy", Author = "maasd", Price = 2, SkinImage = "https://mskins.net/uploads/preview/ee/50/Aleeeeeex-600.png" });
                db.Skins.Add(new Skin { SkinName = "Mouse", Author = "angryL", Price = 3, SkinImage = "https://mskins.net/uploads/preview/ed/bc/angryL-600.png" });

                db.Skins.Add(new Skin { SkinName = "Demon", Author = "Shadwfox", Price = 4, SkinImage = "https://mskins.net/uploads/preview/c6/55/Shadwfox-600.png" });
                db.Skins.Add(new Skin { SkinName = "Blush black girl", Author = "Angen0ah", Price = 2, SkinImage = "https://mskins.net/uploads/preview/34/c9/Angen0ah-600.png" });

                db.Skins.Add(new Skin { SkinName = "Ping Gansa girl", Author = "quts", Price = 2, SkinImage = "https://mskins.net/uploads/preview/06/9b/quts-600.png" });
                db.Skins.Add(new Skin { SkinName = "Frog girl", Author = "Quisli", Price = 3, SkinImage = "https://mskins.net/uploads/preview/26/e1/Quisli-600.png" });

                db.Skins.Add(new Skin { SkinName = "Monkey de luffi", Author = "Quisl", Price = 5, SkinImage = "https://mskins.net/uploads/preview/d3/78/Quisl-600.png" });
                db.Skins.Add(new Skin { SkinName = "Gotick Maiden", Author = "meikyi", Price = 2, SkinImage = "https://mskins.net/uploads/preview/5c/ef/meikyi-600.png" });

                db.Skins.Add(new Skin { SkinName = "HM Super Hero", Author = "Guildes", Price = 3, SkinImage = "https://mskins.net/uploads/preview/01/b4/Guildes_-600.png" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Skin> Get()
        {
            return db.Skins.ToList();
        }

        [HttpGet("{id}")]
        public Skin Get(int id)
        {
            Skin skin = db.Skins.FirstOrDefault(x => x.Id == id);
            return skin;
        }

        [HttpPost]
        public IActionResult Post(Skin skin)
        {
            if (ModelState.IsValid)
            {
                db.Skins.Add(skin);
                db.SaveChanges();
                return Ok(skin);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Skin skin)
        {
            if (ModelState.IsValid)
            {
                db.Update(skin);
                db.SaveChanges();
                return Ok(skin);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Skin skin = db.Skins.FirstOrDefault(x => x.Id == id);
            if (skin != null)
            {
                db.Skins.Remove(skin);
                db.SaveChanges();
            }
            return Ok(skin);
        }
    }
}
