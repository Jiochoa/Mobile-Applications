package edu.utep.cs.cs4330.mypricewatcher;

import java.util.Random;

public class Item {

    private String itemName;
    private String URL;
    private double initialPrice;
    private double currentPrice;

    public Item() {
        itemName = "Samsung Galaxy 4.1";
        URL = "Amazon.com/buy/samsungG";
        initialPrice = 0;
        currentPrice = 0;
    }


    public int getPercentageChange() {

        double theDifference = this.currentPrice - this.initialPrice;
//        double theDifference = currPrice - initPrice;

        double theRatio = theDifference / this.currentPrice;
        double total = theRatio * 100;
        return (int)total;
    }


    public void updateCurrentPrice() {

        Random rand = new Random();

        this.initialPrice = this.currentPrice;
        this.currentPrice = rand.nextDouble() * 100;
    }


    public String getItemName() {
        return itemName;
    }

    public void setItemName(String itemName) {
        this.itemName = itemName;
    }

    public double getInitialPrice() {
        return initialPrice;
    }

    public void setInitialPrice(double initialPrice) {
        this.initialPrice = initialPrice;
    }

    public double getCurrentPrice() {
        return currentPrice;
    }

    public void setCurrentPrice(double currentPrice) {
        this.currentPrice = currentPrice;
    }

    public String getURL() {
        return URL;
    }

    public void setURL(String URL) {
        this.URL = URL;
    }

//    public static void main(String[] args) {
//
//        System.out.println("This is a test");
//
//        Item theItem = new Item();
//
//        theItem.setCurrentPrice(10.0);
//        theItem.setInitialPrice(11.0);
//
//        System.out.println(
//                theItem.getPercentageChange(
//                        theItem.getInitialPrice(), theItem.getCurrentPrice()));
//    }

}

