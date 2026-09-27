using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Tesla Model Y Full Review", "Car Reviews", 1380);
        video1.AddComment(new Comment("John", "Great Review!"));
        video1.AddComment(new Comment("CarEnthusiast07", "I really like this car"));
        video1.AddComment(new Comment("Justin B.", "They use key cards instead of keys???"));
        videos.Add(video1);

        Video video2 = new Video("Introducing the new iPhone Duo", "Apple", 187);
        video2.AddComment(new Comment("Jefferson1078", "I love this new foldable Apple phone!"));
        video2.AddComment(new Comment("JohnFootball", "I love watching videos of phones that I won't buy"));
        video2.AddComment(new Comment("Sophieee", "I definitely recommend this phone."));
        video2.AddComment(new Comment("Mark_Z", "This is one of the best phones I've seen so far!"));
        videos.Add(video2);

        Video video3 = new Video("How to Make Homemade Pizza", "Cooking at Home", 685);
        video3.AddComment(new Comment("LostGuy99", "My pizza burned..."));
        video3.AddComment(new Comment("MartinTheGreatest", "This looks delicious!"));
        video3.AddComment(new Comment("Frank", "I will definitely try this recipe."));
        videos.Add(video3);

        foreach(Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()}s");
            Console.WriteLine($"Number Of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach(Comment comment in video.GetComments())
            {
                Console.WriteLine($"> {comment.GetDisplayText()}");
            }

            Console.WriteLine("");
        }
    }
}