package edu.utep.cs.cs4330.mypricewatcher;

public interface IPriceFinder {

    // Returns price in double from a given URL of an Item
    double findPrice(String URL);
}
