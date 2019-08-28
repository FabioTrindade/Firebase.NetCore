using FirebaseNet.Database;
using static System.Console;

//https://www.ashishvishwakarma.com/creating-c-sharp-wrapper-over-firebase-api-for-basic-crud/

namespace Firebase.NetCore
{
    /// <summary>
    /// Examples
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        public static void Main()
        {
            // Instanciating with base URL
            FirebaseDB firebaseDB = new FirebaseDB("https://c-sharpfirebase-da710.firebaseio.com/");

            // Referring to Node with name "Teams"
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Teams");

            var data = @"{
                            'Team-Awesome': {
                                'Members': {
                                    'M1': {
                                        'City': 'Hyderabad',
                                        'Name': 'Ashish'
                                        },
                                    'M2': {
                                        'City': 'Cyberabad',
                                        'Name': 'Vivek'
                                        },
                                    'M3': {
                                        'City': 'Secunderabad',
                                        'Name': 'Pradeep'
                                        }
                                   }
                               }
                          }";

            WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            WriteLine(getResponse.Success);
            if (getResponse.Success)
                WriteLine(getResponse.JSONContent);
            WriteLine();

            WriteLine("PUT Request");
            FirebaseResponse putResponse = firebaseDBTeams.Put(data);
            WriteLine(putResponse.Success);
            WriteLine();

            WriteLine("POST Request");
            FirebaseResponse postResponse = firebaseDBTeams.Post(data);
            WriteLine(postResponse.Success);
            WriteLine();

            WriteLine("PATCH Request");
            FirebaseResponse patchResponse = firebaseDBTeams
                // Use of NodePath to refer path lnager than a single Node
                .NodePath("Team-Awesome/Members/M1")
                .Patch("{\"Designation\":\"CRM Consultant\"}");
            WriteLine(patchResponse.Success);
            WriteLine();

            WriteLine("DELETE Request");
            FirebaseResponse deleteResponse = firebaseDBTeams.Delete();
            WriteLine(deleteResponse.Success);
            WriteLine();

            WriteLine(firebaseDBTeams.ToString());

            ReadLine();
        }
    }
}
