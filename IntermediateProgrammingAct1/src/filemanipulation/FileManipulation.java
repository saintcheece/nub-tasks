
package filemanipulation;

import java.io.*;
import java.util.Scanner;

public class FileManipulation {

    
    public static void main(String[] args) {
        
        Scanner scan = new Scanner(System.in);
        
        System.out.print("Enter txt file name: ");
        String fileName = scan.nextLine();
        fileName = fileName + ".txt";
        
        createFile(fileName);
        
        System.out.print("Enter new entry on file: ");
        String fileEntry = scan.nextLine();
        
        writeOnFile(fileEntry, fileName);
        System.out.print("Would you like to read the file? [Y/N]:");
        String ans = scan.nextLine();
        ans = ans.toUpperCase();
        if(ans.equals("Y")){
            readOnFile(fileName);
        }
    }
    
    static void createFile(String fileName){
        try{
            File newFile = new File("C:\\hp\\Desktop\\TEST FOLDER\\" + fileName);
            if(newFile.createNewFile()) {
                System.out.println(">file " + newFile.getName() + " created!");
                System.out.println(">file LOCATED AT: " + newFile.getAbsolutePath());
            }else {
                System.out.println(">file ALREADY EXISTS!");
            }
        }catch (IOException e) {
            System.out.println(">an ERROR occured");
            e.printStackTrace();
        }
    }
    
    static void writeOnFile(String entryQuery, String fileName){
        try{
            FileWriter fileWriter = new FileWriter("C:\\hp\\Desktop\\TEST FOLDER\\"+fileName);
            fileWriter.write(entryQuery);
            fileWriter.close();
            System.out.println(">successfull WROTE to the file: " + fileName);
        } catch (IOException e) {
            System.out.println(">an error occured writing on file.");
            e.printStackTrace();
        }
    }
    
    static void readOnFile(String fileName){
        try{
            File myObject = new File("C:\\hp\\Desktop\\TEST FOLDER\\"+fileName);
            Scanner fileReader = new Scanner(myObject);
            while (fileReader.hasNextLine()) {
                String fileContent = fileReader.nextLine();
                System.out.println(">the file contains: \"" + fileContent + "\"");
            }
            fileReader.close();
        } catch (IOException e) {
            System.out.println(">an error occured reading file.");
            e.printStackTrace();
        }
    }
    
}
