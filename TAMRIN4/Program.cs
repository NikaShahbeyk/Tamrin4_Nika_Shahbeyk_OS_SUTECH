//Tamrin 4_Nika Shahbeyk_Shiraz University Of Technology_Student ID: 400213013
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;



class Program
{
    static async Task Main()
    {
        //show message
        Message();

        List<string> links = new List<string>();

        //choice of user
        string choice = Console.ReadLine();
        if(choice == "1")
        {
            Console.WriteLine("You entered 1, so the program will download from default links!");
            links.Add("https://s3.picofile.com/d/8197558350/e50a1da3-976f-4c14-89e8-7ef53c94549e/J_K_Rowling_H_P00_Prequel.pdf");
            links.Add("https://s6.picofile.com/d/8181532776/c9cef2c1-75d7-4ad9-b064-bbb259fd87d5/J_K_Rowling_H_P01_Sang_e_Jadoo.pdf");
            links.Add("https://s4.picofile.com/d/8181539068/129f9924-70ce-4df9-a1f6-799e7edb2c49/J_K_Rowling_H_P02_HifreyeAsrarAmiz.pdf");
            links.Add("https://s4.picofile.com/d/8181656200/d2b3bfdf-d48f-430c-83b3-091dee315e16/J_K_Rowling_H_P03_ZendaniyeAzkaban.pdf");        }
        if(choice == "2")
        {
            Console.WriteLine("You entered 2, lets enter links: ");
            Console.WriteLine("how many links do you want to enter?");
            string val;
            int number;
            val = Console.ReadLine();
            number = Convert.ToInt32(val);
            for(int i = 0 ; i < number ; i++)
            {
                Console.WriteLine("Enter the link number " + (i+1) + " : ");
                string input = Console.ReadLine();
                links.Add(input);
            }
        }
        if(choice!="1")
        {
            if(choice!="2")
            {
            Console.WriteLine("you entered a wrong number! Please run program again and pay attention!");
            }
        }

        //making object from manager class
        Manager manager = new Manager();

        await manager.startdownload(links);

        Console.WriteLine("Please Press any key to exit!");
        Console.ReadLine();
    }

    static void Message()
    {
        Console.WriteLine("===============================================");
        Console.WriteLine("================program========================");
        Console.WriteLine("===============================================");
        Console.WriteLine("What is your choice? ");
        Console.WriteLine("1. using download links that are in program.");
        Console.WriteLine("2. Entering new Links. ");
        Console.WriteLine("Enter Your Choice: ");
    }
}

public class Manager
{
    public async Task startdownload(List<string> links)
    {
        //we make a single task for reach of them
        List<Task> downloads = new List<Task>();
        foreach(string link in links)
        {
            downloads.Add(DownloadFileAsync(link));
        };

        await Task.WhenAll(downloads);
    }

    private async Task DownloadFileAsync(string link)
    {
        using(WebClient client = new WebClient())
        {
            string filename = link.Substring(link.LastIndexOf('/') + 1);
            await client.DownloadFileTaskAsync(new Uri(link), filename);
            Console.WriteLine("Downloaded File From Link: " + link);
        }
        
    }

}

