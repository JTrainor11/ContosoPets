// the ourAnimals array will store the following: 
using System.Diagnostics.Contracts;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
int maxAge = 25;
int maxStringLength = 100;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    if (!decimal.TryParse(suggestedDonation, out decimal decimalDonation))
    {
        decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
    }

    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic(s)");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    Console.WriteLine($"You selected menu option {menuSelection}.");

    bool validEntry = false;

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add a new animal friend to the ourAnimals array
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();

                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                }
                while (validEntry == false);

                // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry. 
                do
                {
                    int petAge;

                    Console.WriteLine("Enter the pet's age (max age is 25) or enter ? if unknown");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalAge = readResult;

                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);

                            if (petAge > maxAge)
                            {
                                Console.WriteLine($"Maximum valid age is {maxAge}");
                                validEntry = false;
                            }
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }

                    if (!validEntry)
                    {
                        Console.WriteLine("Age must be a valid numeric value.");
                    }
                }
                while (validEntry == false);

                // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    validEntry = true;
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();

                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }

                        if (animalPhysicalDescription.Length > maxStringLength)
                        {
                            Console.WriteLine($"Maximum length; is {maxStringLength} characters.");
                            validEntry = false;
                        }
                    }
                }
                while (!validEntry);


                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    validEntry = true;
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();

                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }

                        if (animalPersonalityDescription.Length > maxStringLength)
                        {
                            Console.WriteLine($"Maximum length; is {maxStringLength} characters.");
                            validEntry = false;
                        }
                    }
                }
                while (!validEntry);

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    validEntry = true;
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();

                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }

                        if (animalNickname.Length > maxStringLength)
                        {
                            Console.WriteLine($"Maximum length is {maxStringLength} characters.");
                            validEntry = false;
                        }
                    }
                }
                while (!validEntry);

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                petCount = petCount + 1;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");

                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete

            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                string petID = ourAnimals[i, 0];

                if (petID.Trim() != "ID #:")
                {
                    int colonPosition = ourAnimals[i, 2].IndexOf(':');
                    int length = ourAnimals[i, 2].Length - colonPosition - 1;
                    string property = ourAnimals[i, 2].Substring(colonPosition + 1, length);

                    if (property.Trim() == "?" || property.Trim() == "")
                    {
                        do
                        {
                            int petAge;

                            Console.WriteLine($"Enter an age for {petID} (max age is 25).");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                animalAge = readResult;

                                if (animalAge != "?")
                                {
                                    validEntry = int.TryParse(animalAge, out petAge);

                                    if (petAge > maxAge)
                                    {
                                        Console.WriteLine($"Maximum valid age is {maxAge}");
                                        validEntry = false;
                                    }
                                }
                                else
                                {
                                    validEntry = false;
                                }
                            }

                            if (!validEntry)
                            {
                                Console.WriteLine("Age must be a valid numeric value.");
                            }
                        }
                        while (!validEntry);
                    }

                    colonPosition = ourAnimals[i, 4].IndexOf(':');
                    length = ourAnimals[i, 4].Length - colonPosition - 1;
                    property = ourAnimals[i, 4].Substring(colonPosition + 1, length);

                    if (property.Trim() == "tbd" || property.Trim() == "")
                    {
                        // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                        do
                        {
                            validEntry = true;
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.ToLower();

                                if (animalPhysicalDescription == "")
                                {
                                    Console.WriteLine("Physical Description cannot be empty");
                                    validEntry = false;
                                }

                                if (animalPhysicalDescription.Length > maxStringLength)
                                {
                                    Console.WriteLine($"Maximum length is {maxStringLength} characters.");
                                    validEntry = false;
                                }
                            }
                        }
                        while (!validEntry);
                    }
                }

                ourAnimals[i, 2] = "Age: " + animalAge;
                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            }

            Console.WriteLine("Age and physical description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            for (int i = 0; i < maxPets; i++)
            {
                string petID = ourAnimals[i, 0];

                if (petID.Trim() != "ID #:")
                {
                    int colonPosition = ourAnimals[i, 3].IndexOf(':');
                    int length = ourAnimals[i, 3].Length - colonPosition - 1;
                    string property = ourAnimals[i, 3].Substring(colonPosition + 1, length);

                    if (property.Trim() == "tbd" || property.Trim() == "")
                    {
                        // get the pet's nickname.
                        do
                        {
                            validEntry = true;
                            Console.WriteLine($"Enter a nickname for {petID}");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                animalNickname = readResult.ToLower();

                                if (animalNickname == "")
                                {
                                    Console.WriteLine("Nickname cannot be empty");
                                    validEntry = false;
                                }

                                if (animalNickname.Length > maxStringLength)
                                {
                                    Console.WriteLine($"Maximum length is {maxStringLength} characters.");
                                    validEntry = false;
                                }
                            }
                        }
                        while (!validEntry);
                    }

                    colonPosition = ourAnimals[i, 5].IndexOf(':');
                    length = ourAnimals[i, 5].Length - colonPosition - 1;
                    property = ourAnimals[i, 5].Substring(colonPosition + 1, length);

                    if (property.Trim() == "tbd" || property.Trim() == "")
                    {
                        // get a description of the pet's personality.
                        do
                        {
                            validEntry = true;
                            Console.WriteLine($"Enter a personality description for {petID} (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.ToLower();

                                if (animalPersonalityDescription == "")
                                {
                                    Console.WriteLine("Personality Description cannot be empty");
                                    validEntry = false;
                                }

                                if (animalPersonalityDescription.Length > maxStringLength)
                                {
                                    Console.WriteLine($"Maximum length is {maxStringLength} characters.");
                                    validEntry = false;
                                }
                            }
                        }
                        while (!validEntry);
                    }
                }

                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
            }

            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Edit an animal's age
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Edit an animal’s personality description
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            // #1 Display all dogs with a multiple search characteristics

            string[] dogCharacteristics = { };
            string dogCharacteristicsSearchString = "";
            int[] matchedDogs = { };
            bool allCharacteristicsValid = false;

            while (!allCharacteristicsValid)
            {
                // #2 have user enter multiple comma separated characteristics to search for
                Console.WriteLine($"\r\nEnter dog characteristics to search for separated by commas");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    dogCharacteristicsSearchString = readResult.ToLower().Trim();
                    dogCharacteristics = dogCharacteristicsSearchString.Replace(" ", "").Split(',');
                    Console.WriteLine();

                    if (dogCharacteristics.Count() == 0)
                    {
                        continue;
                    }

                    allCharacteristicsValid = true;
                    foreach (var dogCharacteristic in dogCharacteristics)
                    {
                        if (string.IsNullOrEmpty(dogCharacteristic))
                        {
                            allCharacteristicsValid = false;
                            break;
                        }
                    }

                    if (!allCharacteristicsValid)
                    {
                        continue;
                    }
                }
            }

            bool noMatchesDog = true;
            bool noMatchesThisDog;
            string dogDescription;

            // #4 update to "rotating" animation with countdown
            string[] searchingIcons = { "|", "/", "-", @"\" };

            // loop ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("dog"))
                {
                    noMatchesThisDog = true;

                    // Search combined descriptions and report results
                    dogDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5];

                    // #3a iterate submitted characteristic terms and search description for each term
                    foreach (var dogCharacteristic in dogCharacteristics)
                    {
                        for (int j = 5; j > -1; j--)
                        {
                            // #5 update "searching" message to show countdown 
                            foreach (string icon in searchingIcons)
                            {
                                Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {dogCharacteristic} {icon} {j}");
                                Thread.Sleep(250);
                            }

                            Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                        }

                        if (dogDescription.Contains(dogCharacteristic))
                        {
                            // #3b update message to reflect term 
                            // #3c set a flag "this dog" is a match
                            Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a {dogCharacteristic} match!");
                            noMatchesDog = false;
                            noMatchesThisDog = false;
                        }
                    }

                    if(!noMatchesThisDog)
                    {
                        Console.WriteLine();
                        Console.Write(ourAnimals[i,3]);
                        Console.WriteLine($"({ourAnimals[i,0]})");
                        Console.WriteLine(ourAnimals[i,4]);
                        Console.WriteLine(ourAnimals[i,5]);
                    }
                }
            }

            if (noMatchesDog)
            {
                Console.Write("None of our dogs are a match for: " + dogCharacteristicsSearchString);
            }

            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        default:
            break;
    }
}
while (menuSelection.ToLower().Trim() != "exit");
