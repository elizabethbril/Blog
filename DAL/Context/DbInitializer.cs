using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.Context
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {

            User user = new User("Liza", UserType.Manager, "Bril", "Login", "Password");
            
            //add page
            context.Pages.Add(new Page("My Blog", " "));
            
            //add post
            context.Posts.Add(new Post(".NET", "It’s good to keep your coding skills sharp, and that’s a tall order these days with the pace and scope of changes in the development landscape. There are constantly new versions of venerable development frameworks and libraries, things moving to open source, and cross-platform workarounds. It’s definitely an exciting time to be part of the development world, and one good way to keep your finger on the pulse of these changes is through the blogosphere.After all, we already know there are some great blog - based resources for Visual Studio and AngularJS, right ?  Four other blogs we've recently come across—three from Microsoft staffers and one from an independent expert—provide an excellent insider’s view to the inner workings of C#.", "C#", "Programming"));
            context.Posts.Add(new Post("Codding Horror", "I didn't choose to be a programmer. Somehow, it seemed, the computers chose me. For a long time, that was fine, that was enough; that was all I needed. But along the way I never felt that being a programmer was this unambiguously great-for-everyone career field with zero downsides", "Story", "Codding"));
            context.Posts.Add(new Post("Which Programming Language Should You Learn For Software Development?", "When starting on the path of programming, it’s important you invest your time wisely in choosing to learn something that will both benefit you in the immediate future with visible results on your platform of choice, as well as getting you set up for any future languages. Your choice will depend upon a number of factors, so let’s take a look at their characteristics, ease of learning, and likelihood of earning you a living. I’ll also show you some code to display “hello world”, the first application many people write when learning a new language. In this first part, we’ll be looking at languages used to program software – as in applications which run on the computer or mobile devices.Next time we’ll look at the increasingly significant area of web - programming languages, used to create dynamic websites and interactive browser - based user interfaces.", "Study", "Study"));

            
            context.Users.Add(user);
            context.SaveChanges();

        }
    }
}
