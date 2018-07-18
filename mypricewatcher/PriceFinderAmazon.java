package edu.utep.cs.cs4330.mypricewatcher;

import java.util.Random;

public class PriceFinderAmazon implements IPriceFinder {

    private Item newItem;



    @Override
    public double findPrice(String URL) {
        Random rand = new Random();
        return rand.nextDouble();
    }

    public Item getNewItem() {
        return newItem;
    }

    public void setNewItem(Item newItem) {
        this.newItem = newItem;
    }


//    public static void main(String[] args) {
//        Random rand = new Random();
//        for (int i = 0; i < 10; i++) {
//            System.out.println(rand.nextDouble());
//        }
//    }
}
