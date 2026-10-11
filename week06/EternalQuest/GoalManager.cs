public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine("");
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                ListGoalDetails();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Your rank is: {GetRank()}");
    }

    public string GetRank()
    {
        if (_score >= 5000)
        {
            return "Legend";
        }
        else if (_score >= 2000)
        {
            return "Champion";
        }
        else if (_score >= 1000)
        {
            return "Expert";
        }
        else if (_score >= 500)
        {
            return "Apprentice";
        }
        else
        {
            return "Beginner";
        }
    }

    public void ListGoalNames()
    {
        Console.WriteLine($"\nThe goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine($"\nThe goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            string status = "[ ]";
            if (_goals[i].IsComplete())
            {
                status = "[X]";
            }

            Console.WriteLine($"{i + 1}. {status} {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            _goals.Add(new SimpleGoal(name, description, points));
        }

        else if (type == 2)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            _goals.Add(new EternalGoal(name, description, points));
        }

        else if (type == 3)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals.");
        }
        else
        {
            ListGoalNames();

            Console.Write("Which goal did you accomplish? ");
            int number = int.Parse(Console.ReadLine());

            if (number >= 1 && number <= _goals.Count)
            {
                Goal goal = _goals[number - 1];

                if (goal.IsComplete())
                {
                    Console.WriteLine("This goal is already complete.");
                }
                else
                {
                    int pointsEarned = goal.RecordEvent();
                    _score += pointsEarned;

                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                    Console.WriteLine($"You now have {_score} points.");
                }
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                if (type == "SimpleGoal")
                {
                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    goal.SetComplete(bool.Parse(parts[4]));
                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (type == "ChecklistGoal")
                {
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                    goal.SetAmountCompleted(amountCompleted);
                    _goals.Add(goal);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}