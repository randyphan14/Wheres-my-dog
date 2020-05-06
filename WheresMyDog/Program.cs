using System;
using System.Collections.Generic;

namespace WheresMyDog
{
    class Player
    {
        public string Name;
        public string Location;

        public Location House;

        public List<HidingSpot> HidingSpotsSearched;

        public bool found;

        public Player(string name)
        {
            Name = name;
            Location = "Start";
            House = new Location("House");
            HidingSpotsSearched = new List<HidingSpot>();
            found = false;

            //for testing purpose
            // foreach(var item in House.HidingSpots){
            //     Console.WriteLine($"The room is {item.RoomName}, spot name is {item.HidingSpotsName}, and the object is here?{item.IsObject}");
            // }
        }

        //move method
        public void Move() {
            string move;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($" _____________________________________________\n|.'',                                     ,''.|\n|.'.'',                                 ,''.'.|\n|.'.'.'',                             ,''.'.'.|\n|.'.'.'.'',                         ,''.'.'.'.|\n|.'.'.'.'.|                         |.'.'.'.'.|\n|.'.'.'.'.|===;                 ;===|.'.'.'.'.|\n|.'.'.'.'.|:::|',             ,'|:::|.'.'.'.'.|\n|.'.'.'.'.|---|'.|, _______ ,|.'|---|.'.'.'.'.|\n|.'.'.'.'.|:::|'.|'|???????|'|.'|:::|.'.'.'.'.|\n|,',',',',|---|',|'|???????|'|,'|---|,',',',',|\n|.'.'.'.'.|:::|'.|'|???????|'|.'|:::|.'.'.'.'.|\n|.'.'.'.'.|---|','   /%%%\\   ','|---|.'.'.'.'.|\n|.'.'.'.'.|===:'    /%%%%%\\    ':===|.'.'.'.'.|\n|.'.'.'.'.|%%%%%%%%%%%%%%%%%%%%%%%%%|.'.'.'.'.|\n|.'.'.'.','       /%%%%%%%%%\\       ','.'.'.'.|\n|.'.'.','        /%%%%%%%%%%%\\        ','.'.'.|\n|.'.','         /%%%%%%%%%%%%%\\         ','.'.|\n|.','          /%%%%%%%%%%%%%%%\\          ','.|\n|;____________/%%%%%%%%%%%%%%%%%\\____________;|\n");
            Console.WriteLine("Here are your options:");
            foreach (var room in House.roomname) {
                Console.WriteLine(room);
            }
            while ((move = Console.ReadLine()) != null)
            {

                if (move == "Bedroom") {
                    this.Location = "Bedroom";
                    return;
                } else if (move == "Kitchen") {
                    this.Location = "Kitchen";
                    return;
                } else if (move == "Bathroom") {
                    this.Location = "Bathroom";
                    return;
                } else if (move == "Living Room") {
                    this.Location = "Living Room";
                    return;
                } else {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Input was invalid");
                    move = null;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Here are your options:");
                    foreach (var room in House.roomname) {
                        Console.WriteLine(room);
                    }
                    // return;
                }
                
            }
        }
        //search method
        public void Search() {
            string move;
            List<string> temp = new List<string> ();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Where would you like to search?");
            Console.WriteLine("Here are your options:");
            if (this.Location == "Bedroom") {
                foreach (var room in House.bedroomHidingSpotsname) {
                    Console.WriteLine(room);
                    temp = House.bedroomHidingSpotsname;
                }
            } else if (this.Location == "Kitchen") {
                foreach (var room in House.kitchenHidingSpotsname) {
                    Console.WriteLine(room);
                    temp = House.kitchenHidingSpotsname;
                }
            } else if (this.Location == "Living Room") {
                foreach (var room in House.livingRoomHidingSpotsname) {
                    Console.WriteLine(room);
                    temp = House.livingRoomHidingSpotsname;
                }
            } else {
                foreach (var room in House.bathroomHidingSpotsname) {
                    Console.WriteLine(room);
                    temp = House.bathroomHidingSpotsname;
                }
            }
            
            while ((move = Console.ReadLine()) != null)
            {
                if (temp.Contains(move)) {

                    Console.WriteLine($"You are searching {this.Location}/{move}");
                    foreach (var spot in House.HidingSpots) {
                        if (this.Location == spot.RoomName && move == spot.HidingSpotsName) {
                            if (spot.IsObject == true) {
                                Console.WriteLine("You've found your dog!");
                                this.found = true;
                                return;
                            } else {
                                Console.WriteLine("Sorry, your dog is not here");
                                return;
                            }
                        } else {

                        }
                    }
                } else {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Input was invalid");
                    move = null;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Here are your options:");
                    // foreach (var room in House.hidingSpotsname) {
                    //     Console.WriteLine(room);
                    // }
                    if (this.Location == "Bedroom") {
                        foreach (var room in House.bedroomHidingSpotsname) {
                            Console.WriteLine(room);
                        }
                    } else if (this.Location == "Kitchen") {
                        foreach (var room in House.kitchenHidingSpotsname) {
                            Console.WriteLine(room);
                        }
                    } else if (this.Location == "Living Room") {
                        foreach (var room in House.livingRoomHidingSpotsname) {
                            Console.WriteLine(room);
                        }
                    } else {
                        foreach (var room in House.bathroomHidingSpotsname) {
                            Console.WriteLine(room);
                        }
                    }
                }
                
            }
        }

        public void Cheat() {
            Console.WriteLine($"You hear a bark coming from the {House.cheat.RoomName}");
        }
    }

    class Location 
    {
        public string Type;
        public List<HidingSpot> HidingSpots;
        public List<string> roomname = new List<string>{"Bedroom", "Kitchen", "Bathroom", "Living Room"};
        public List<string> hidingSpotsname = new List<string>{"Closet", "Shelf", "Curtain", "Rug"};

        public List<string> bedroomHidingSpotsname = new List<string>{"Bed", "Closet", "Curtains", "Rug"};

        public List<string> kitchenHidingSpotsname = new List<string>{"Sink", "Pantry", "Oven"};

        public List<string> bathroomHidingSpotsname = new List<string>{"Sink", "Rug", "Shower", "Bathtub"};

        public List<string> livingRoomHidingSpotsname = new List<string>{"Couch", "Rug", "Coffee Table", "Curtains"};
        public List<List<string>> listnames;
        
        public HidingSpot cheat;


        public Location(string type)
        {
            Type = type;
            HidingSpots = new List<HidingSpot>();
            listnames = new List<List<string>>();
            listnames.Add(bedroomHidingSpotsname);
            listnames.Add(kitchenHidingSpotsname);
            listnames.Add(bathroomHidingSpotsname);
            listnames.Add(livingRoomHidingSpotsname);
            Random rand = new Random();
            foreach (string room in roomname)
            {
                if (room == "Bedroom") {
                    foreach (string item in bedroomHidingSpotsname) {
                        HidingSpots.Add(new HidingSpot(room, item, false));
                    }
                } else if (room == "Kitchen") {
                    foreach (string item in kitchenHidingSpotsname) {
                        HidingSpots.Add(new HidingSpot(room, item, false));
                    }
                } else if (room == "Bathroom") {
                    foreach (string item in bathroomHidingSpotsname) {
                        HidingSpots.Add(new HidingSpot(room, item, false));
                    }
                } else {
                    foreach (string item in livingRoomHidingSpotsname) {
                        HidingSpots.Add(new HidingSpot(room, item, false));
                    }
                }
                // foreach (List<string> subList in listnames) {
                //     foreach (string item in subList) {
                //         HidingSpots.Add(new HidingSpot(room, item, false));
                //     }
                // }
            }
            // Console.WriteLine(HidingSpots.Count);
            // Console.WriteLine(n);
            int n = rand.Next(HidingSpots.Count);
            HidingSpots[n].IsObject = true;
            cheat = HidingSpots[n];



            // int n = rand.Next(17);
            // int i=0;
            // foreach (string room in roomname)
            // {
            //     foreach (string spot in hidingSpotsname)
            //     {
            //         if(i==n)
            //         {
            //             HidingSpots.Add(new HidingSpot(room,spot,true));
            //         }
            //         else
            //         {
            //             HidingSpots.Add(new HidingSpot(room,spot,false));
            //         }
            //         i++;
            //     }

            // }
            
        }

    }
    class HidingSpot
    {
        public string RoomName;
        public string HidingSpotsName;
        public bool IsObject;

        public HidingSpot(string roomname, string hidingspotsname, bool isObject){
            RoomName=roomname;
            HidingSpotsName = hidingspotsname;
            IsObject = isObject;
        }

        public HidingSpot(){
        }
    }


    // class Object
    // {
    //     public string Type;
    //     public Object(string type){
    //         Type = type;
    //         Location = 
    //     }
    // }

    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string location;
            Console.WriteLine("Welcome!");
            Console.WriteLine("You have lost your dog and are trying to find him/her");
            Console.WriteLine("To play, please type your name");
            name = Console.ReadLine();
            Player player = new Player(name);



            Console.WriteLine($"Welcome {name}!");
            Console.WriteLine("Where was the last time you saw your dog?");
            while ((location = Console.ReadLine()) != null)
            {
                if (location == "House") {
                    Console.WriteLine("             (\n                )\n            (            ./\\.\n         |^^^^^^^^^|   ./LLLL\\.\n         |`.'`.`'`'| ./LLLLLLLL\\.\n         |.'`'.'`.'|/LLLL/^^\\LLLL\\.\n         |.`.''``./LLLL/^ () ^\\LLLL\\.\n         |.'`.`./LLLL/^  =   = ^\\LLLL\\.\n         |.`../LLLL/^  _.----._  ^\\LLLL\\.\n         |'./LLLL/^ =.' ______ `.  ^\\LLLL\\.\n         |/LLLL/^   /|--.----.--|\\ = ^\\LLLL\\.\n       ./LLLL/^  = |=|__|____|__|=|    ^\\LLLL\\.\n     ./LLLL/^=     |*|~~|~~~~|~~|*|   =  ^\\LLLL\\.\n   ./LLLL/^        |=|--|----|--|=|        ^\\LLLL\\.\n ./LLLL/^      =   `-|__|____|__|-' =        ^\\LLLL\\.\n/LLLL/^   =         `------------'        =    ^\\LLLL\\ \n~~|.~       =        =      =          =         ~.|~~\n  ||     =      =      = ____     =         =     ||\n  ||  =               .-'    '-.        =         ||\n  ||     _..._ =    .'  .-()-.  '.  =   _..._  =  ||\n  || = .'_____`.   /___:______:___\\   .'_____`.   ||\n  || .-|---.---|-.   ||  _  _  ||   .-|---.---|-. ||\n  || |=|   |   |=|   || | || | ||   |=|   |   |=| ||\n  || |=|___|___|=|=  || | || | ||=  |=|___|___|=| ||\n  || |=|~~~|~~~|=|   || | || | ||   |=|~~~|~~~|=| ||\n  || |*|   |   |*|   || | || | ||  =|*|   |   |*| ||\n  || |=|---|---|=| = || | || | ||   |=|---|---|=| ||\n  || |=|   |   |=|   || | || | ||   |=|   |   |=| ||\n  || `-|___|___|-'   ||o|_||_| ||   `-|___|___|-' ||\n  ||  '---------`  = ||  _  _  || =  `---------'  ||\n  || =   =           || | || | ||      =     =    ||\n  ||  %@&   &@  =    || |_||_| ||  =   @&@   %@ = ||\n  || %@&@% @%@&@    _||________||_   &@%&@ %&@&@  ||\n  |--------------|____/--------\\____|--------------|\n /- _  -  _   - _ -  _ - - _ - _ _ - _  _-  - _ - _ \\ \n/____________________________________________________\\");
                    Console.WriteLine("Let go check out the house");
                    break;
                } else {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Input was invalid");
                    location = null;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Where was the last time you saw your dog?");
                    Console.WriteLine("Hint: you have one option, House");
                }
                
            }



            Console.WriteLine($"You are inside your {location} and you are looking for your dog");

            string move;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Your options are: Search or Move");
            while ((move = Console.ReadLine()) != null)
            {
                if (move == "Move") {
                    Console.WriteLine("You are moving");
                    player.Move();
                    move = null;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Your options are: Search or Move");
                } else if (move == "Search") {
                    Console.WriteLine("You are searching");
                    player.Search();
                    if (player.found == true) {
                        break;
                    }
                    move = null;    
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Your options are: Search or Move");
                } else if (move == "Cheat") {
                    player.Cheat();
                    move = null;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Your options are: Search or Move");
                } else {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Input was invalid");
                    move = null;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Your options are: Search or Move");
                }
                
            }
            Console.WriteLine("           __.\n        .-\".'                      .--.            _..._\n      .' .'                     .'    \\       .-\"\"  __ \"\"-.\n     /  /                     .'       : --..:__.-\"\"  \"\"-. \\ \n    :  :                     /         ;.d$$    sbp_.-\"\"-:_:\n    ;  :                    : ._       :P .-.   ,\"TP\n    :   \\                    \\  T--...-; : d$b  :d$b\n     \\   `.                   \\  `..'    ; $ $  ;$ $\n      `.   \"-.                 ).        : T$P  :T$P\n        \\..---^..             /           `-'    `._`._\n       .'        \"-.       .-\"                     T$$$b\n      /             \"-._.-\"               ._        '^' ;\n     :                                    \\.`.         /\n     ;                                -.   \\`.\"-._.-'-'\n    :                                 .'\\   \\ \\ \\ \\ \n    ;  ;                             /:  \\   \\ \\ . ;\n   :   :                            ,  ;  `.  `.;  :\n   ;    \\        ;                     ;    \"-._:  ;\n  :      `.      :                     :         \\/\n  ;       /\"-.    ;                    :\n :       /    \"-. :                  : ;\n :     .'        T-;                 ; ;\n ;    :          ; ;                /  :\n ;    ;          : :              .'    ;\n:    :            ;:         _..-\"\\     :\n:     \\           : ;       /      \\     ;\n;    . '.         '-;      /        ;    :\n;  \\  ; :           :     :         :    '-.\n'.._L.:-'           :     ;          ;    . `.\n                     ;    :          :  \\  ; :\n                     :    '-..       '.._L.:-'\n                      ;     , `.\n                      :   \\  ; :\n                      '..__L.:-'");
            //we'll print the doggy

            

            // foreach(var item in House.HidingSpots){
            //     Console.WriteLine($"The room is {item.RoomName}, spot name is {item.HidingSpotsName}, and the object is here?{item.IsObject}");
            // }
            
            //player enters name  << create player object

            //player chooses location <<  one option to start - but we could expand this
                //initialize a new location

            //player chooses object  <<  one option to start - but we could expand this
                //object is placed in random room - DONE


            //player would begin at hidingspots[0].roomname

            //player can move, search room, and will view hiding spots that match its own roonname
                    // create player methods

                    //at each moment - player can move or search

                    //if search hidingpot bool is true  - game is over


        }
    }
}
