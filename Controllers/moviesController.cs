using MoviesProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        moviesDBEntities3 db = new moviesDBEntities3();

        public string SearchString { get; private set; }

        public ActionResult Index(string SearchString, string MovieGenre)
        {

                        List<string> genreList = new List<string>();
            var genreQuery = from g in db.Movies
                             orderby g.genre
                             select g.genre;
            genreList.AddRange(genreQuery.Distinct());
            ViewBag.MovieGenre = new SelectList(genreList);

            var movies = from m in db.Movies
                         select m;



            if(!String.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.genre == MovieGenre);
            }

            //return View(movies);
            
            if(!String.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(x => x.title.Contains(SearchString));
            }

            return View(movies);
        }


        
        
        [HttpGet]

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Id, price, genre, title, releaseDate, images, ImageFile")] Movie mv)
        {
            if (ModelState.IsValid)
            {
                string imagename = Path.GetFileNameWithoutExtension(mv.ImageFile.FileName);
                string extension = Path.GetExtension(mv.ImageFile.FileName);
                imagename = imagename + extension;
                mv.images = imagename;

                imagename = Path.Combine(Server.MapPath("~/Content/img/"), imagename);
                mv.ImageFile.SaveAs(imagename);

                db.Movies.Add(mv);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
            

            
        }


        public ActionResult Detail(int Id)
        {
            Movie mv = db.Movies.Find(Id);
            return View(mv);
        }

        public ActionResult Edit(int id)
        {
            Movie movie = db.Movies.Find(id);
            return View(movie);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);

            return View(movie);
        }



        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) 
        { 
            Movie movie = db.Movies.Find(id); 
            db.Movies.Remove(movie); 
            db.SaveChanges(); 
            return RedirectToAction("Index"); 
        }


        //public ActionResult upload()
        //{
        //    return View();
        //}

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }

}