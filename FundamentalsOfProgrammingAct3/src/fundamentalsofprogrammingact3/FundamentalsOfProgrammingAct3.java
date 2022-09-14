
package fundamentalsofprogrammingact3;

import java.util.Scanner;


public class FundamentalsOfProgrammingAct3 {
    
        static Scanner scan = new Scanner(System.in);
        
        //VARIABLES
    
        //customer info
        static String customerName;
        static String customerAddress;
        
        //item1
        static int item1Code;
        static String item1Desc;
        static double item1Price;
        
        //item2
        static int item2Code;
        static String item2Desc;
        static double item2Price;
        
        //item3
        static int item3Code;
        static String item3Desc;
        static double item3Price;
        
        //transaction
        static double total;
        static double cashTendered;
        static double change;

    
    public static void main(String[] args) {
        
        /*In this 3rd task for our subject Fundamentals of Programming, we were tasked
        to make a code-based calculation receipt similar to grocery stores, but specifically
        for this program, is a school supply shop using either IF/ELSE and SWITCH statements.*/ 
        
        //Input
        GetCustomerInfo();
        GetItems();
        GetCash();
        
        //Identify Items
        SetItem1(item1Code);
        SetItem2(item2Code);
        SetItem3(item3Code);
        
        //Calculate
        CalculateItemTotal(item1Price, item2Price, item3Price);
        CalculateChange(cashTendered, total);
        
        /*By the end of this activity, I ended up using both, with SWITCH using the main factor for
        setting the values based on item codes and IF/ELSE for technical conditions wherein insufficient
        cash tenders compared to the total of input products will stop the program.*/
        
        //Output
        if(cashTendered < total) {
            PrintInsufficientError();
        } else {
            PrintReceipt();
        }
        
    }
    
    /*I later applied using method/objects in preparing myself to the forseen topic of
    object orriented programming which you will see more commonly to incoming projects.*/
    
    static void GetCustomerInfo() {
        System.out.print("Enter CUSTOMER NAME: ");
        customerName = scan.nextLine();
        
        System.out.print("Enter CUSTOMER ADDRESS: ");
        customerAddress = scan.nextLine();
    }
    
    static void GetItems() {
        System.out.print("Enter ITEM 1 code: ");
        item1Code = scan.nextInt();
        
        System.out.print("Enter ITEM 2 code: ");
        item2Code = scan.nextInt();
        
        System.out.print("Enter ITEM 3 code: ");
        item3Code = scan.nextInt();
    }
    
    static void GetCash() {
        System.out.print("Enter CASH TENDERED: ");
        cashTendered = scan.nextInt();
    }
    
    static void SetItem1(int item1Code) {
        switch(item1Code) {
            case 1:
                item1Desc = "BlkPen";
                item1Price = 15;
                break;
            case 2: 
                item1Desc = "BckBag";
                item1Price = 2000;
                break;
            case 3: 
                item1Desc = "Ntbook";
                item1Price = 50;
                break;
            case 4: 
                item1Desc = "Eraser";
                item1Price = 10;
                break;
            case 5: 
                item1Desc = "Pencil";
                item1Price = 15;
                break;
            case 6: 
                item1Desc = "Unform";
                item1Price = 2500;
                break;
            default: 
                item1Desc = "Invald";
                item1Price = 0;
                break;
        }
    }
    
    static void SetItem2(int item2Code) {
        switch(item2Code) {
            case 0:
                item3Desc = "<None>";
                item3Price = 0;
                break;
            case 1:
                item2Desc = "BlkPen";
                item2Price = 15;
                break;
            case 2: 
                item2Desc = "BckBag";
                item2Price = 2000;
                break;
            case 3: 
                item2Desc = "Ntbook";
                item2Price = 50;
                break;
            case 4: 
                item2Desc = "Eraser";
                item2Price = 10;
                break;
            case 5: 
                item2Desc = "Pencil";
                item2Price = 15;
                break;
            case 6: 
                item2Desc = "Unform";
                item2Price = 2500;
                break;
            default: 
                item2Desc = "Invald";
                item2Price = 0;
                break;
        }
    }
    
    static void SetItem3(int item3Code) {
        switch(item3Code) {
            case 0:
                item3Desc = "<None>";
                item3Price = 0;
                break;
            case 1:
                item3Desc = "BlkPen";
                item3Price = 15;
                break;
            case 2: 
                item3Desc = "BclBag";
                item3Price = 2000;
                break;
            case 3: 
                item3Desc = "Ntbook";
                item3Price = 50;
                break;
            case 4: 
                item3Desc = "Eraser";
                item3Price = 10;
                break;
            case 5: 
                item3Desc = "Pencil";
                item3Price = 15;
                break;
            case 6: 
                item3Desc = "Unform";
                item3Price = 2500;
                break;
            default: 
                item3Desc = "Invald";
                item3Price = 0;
                break;
        }
    }
    
    static double CalculateItemTotal(double item1Price, double item2Price, double item3Price) {
        total = item1Price + item2Price + item3Price;
        return total;
    }
    
    static double CalculateChange(double cashTendered, double total) {
        change = cashTendered - total;
        return change;
    }
    
    static void PrintReceipt() {
        System.out.println("===================================" + "\n"
                         + "         PURCHASE INFO:" + "\n"
                         + "===================================" + "\n"
                         + "CUSTOMER NAME: " + customerName + "\n"
                         + "CUSTOMER ADDRESS: " + customerAddress + "\n"
                         + "PURCHASED ITEMS: " + "\n"
                         + "NO. " + "ID  " + "ITEM NAME  " + "PRICE" + "\n"
                         + "(1)" + " " + item1Code + "   " + item1Desc + "     -" + item1Price + "\n"
                         + "(2)" + " " + item2Code + "   " + item2Desc + "     -" + item2Price + "\n"
                         + "(3)" + " " + item3Code + "   " + item3Desc + "     -" + item3Price + "\n"
                         + "-----------------------------------" + "\n"
                         + "ITEM PURCHASE TOTAL:     " + total + "\n"
                         + "CASH TENDERED:           " + cashTendered + "\n"
                         + "CHANGE:                  " + change + "\n"
                         + "===================================");
    }
    
    static void PrintInsufficientError() {
        System.out.println("==========================="
                             + "INSUFFICIENT CASH TENDERED!"
                             + "===========================");
    }
}
