package edu.utep.cs.cs4330.mypricewatcher;


import android.os.PersistableBundle;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.text.DecimalFormat;
import java.text.NumberFormat;


public class MainActivity extends AppCompatActivity {

    private Button btnRefresh;
    private TextView textView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        final Item theItem = new Item();

        textView = (TextView) findViewById(R.id.txtItemName);
        textView.setText(theItem.getItemName());

        textView = (TextView) findViewById(R.id.txtCurrentPrice);
        textView.setText(Double.toString(theItem.getCurrentPrice()));

        textView = (TextView) findViewById(R.id.txtInitialValue);
        textView.setText((Double.toString(theItem.getInitialPrice())));

        textView = (TextView) findViewById(R.id.txtPercentageChange);
        textView.setText(Double.toString(theItem.getPercentageChange()));

        Button btn = (Button) findViewById(R.id.btnRefresh);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

//                theItem.setInitialPrice(theItem.getCurrentPrice());
                theItem.updateCurrentPrice();

                NumberFormat formatter = new DecimalFormat("#0.00");

                textView = (TextView) findViewById(R.id.txtCurrentPrice);
                textView.setText("$" +
                        formatter.format(theItem.getCurrentPrice()
                ));
//                textView.setText(Double.toString(theItem.getCurrentPrice()));

                textView = (TextView) findViewById(R.id.txtInitialValue);
                textView.setText("$" +
                        formatter.format(theItem.getInitialPrice())
                );
//                textView.setText((Double.toString(theItem.getInitialPrice())));

                textView = (TextView) findViewById(R.id.txtPercentageChange);
                textView.setText("%" +
                        formatter.format(theItem.getPercentageChange())
                );
//                textView.setText(Double.toString(theItem.getPercentageChange()));
            }
        });

    }


    @Override
    public void onSaveInstanceState(Bundle outState, PersistableBundle outPersistentState) {


        outState.putString("initPrice", textView.getText().toString());
        super.onSaveInstanceState(outState, outPersistentState);
    }


    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        textView.setText(savedInstanceState.getString("initPrice"));


    }
}
