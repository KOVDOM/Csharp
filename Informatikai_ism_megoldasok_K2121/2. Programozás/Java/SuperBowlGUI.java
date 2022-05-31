import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Text;
import javafx.stage.Stage;

import java.util.ArrayList;
import java.util.List;

class Szam {
    private Integer arabErtek;
    private String romaiErtek;

    Integer getArabErtek() {
        return arabErtek;
    }

    String getRomaiErtek() {
        return romaiErtek;
    }

    Szam(Integer arabErtek, String romaiErtek) {
        this.arabErtek = arabErtek;
        this.romaiErtek = romaiErtek;
    }
}

class SzamValto {
    List<Szam> szamList = new ArrayList<>();

    SzamValto() {
        szamList.add(new Szam(1, "I"));
        szamList.add(new Szam(2, "II"));
        szamList.add(new Szam(3, "III"));
        szamList.add(new Szam(4, "IV"));
        szamList.add(new Szam(5, "V"));
        szamList.add(new Szam(6, "VI"));
        szamList.add(new Szam(7, "VII"));
        szamList.add(new Szam(8, "VIII"));
        szamList.add(new Szam(9, "IX"));
        szamList.add(new Szam(10, "X"));
    }

    Integer romaiValtas(String romaiSzam) {
        for (Szam szam : szamList) {
            if (szam.getRomaiErtek().equals(romaiSzam.toUpperCase())) {
                return szam.getArabErtek();
            }
        }
        return -1;
    }

    String arabValtas(Integer arabSzam) {
        if (arabSzam > 0 && arabSzam <= 10) {
            return szamList.get(arabSzam - 1).getRomaiErtek();
        }
        return "Hiba!";
    }
}

public class SuperBowlGUI extends Application {
    Boolean jobbraMutat = true;

    public void start(Stage stage) {
        // 8. feladat a.)
        Text feliratRomaiSzam = new Text("Római szám [I-X]:");
        TextField inputRomaiSzam = new TextField();
        Button jobbraNyilGomb = new Button("--->");
        Button atvaltGomb = new Button("Átvált");
        Text feliratArabSzam = new Text("Arab szám[1-10]:");
        TextField inputArabSzam = new TextField();
        inputArabSzam.setDisable(true);

        GridPane gridPane = new GridPane();
        gridPane.add(feliratRomaiSzam, 0, 0);
        gridPane.add(inputRomaiSzam, 0, 1);
        gridPane.add(jobbraNyilGomb, 1, 0);
        gridPane.add(atvaltGomb, 1, 2);
        gridPane.add(feliratArabSzam, 2, 0);
        gridPane.add(inputArabSzam, 2, 1);

        gridPane.setPadding(new Insets(20, 20, 20, 20));
        gridPane.setVgap(10);
        gridPane.setAlignment(Pos.CENTER);

        Scene scene = new Scene(gridPane, 500, 150);
        stage.setTitle("Átváltó");
        stage.setScene(scene);
        stage.show();

        // 8. feladat b.)
        jobbraNyilGomb.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                inputRomaiSzam.textProperty().set("");
                inputArabSzam.textProperty().set("");
                if (jobbraMutat) {
                    jobbraMutat = false;
                    jobbraNyilGomb.textProperty().set("<---");
                    inputRomaiSzam.setDisable(true);
                    inputArabSzam.setDisable(false);
                } else {
                    jobbraMutat = true;
                    jobbraNyilGomb.textProperty().set("--->");
                    inputRomaiSzam.setDisable(false);
                    inputArabSzam.setDisable(true);
                }
            }
        });

        // 8. feladat c.)
        SzamValto szamValto = new SzamValto();
        atvaltGomb.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent event) {
                if (jobbraMutat) {
                    String romaiSzam = inputRomaiSzam.getText();
                    Integer eredmeny = szamValto.romaiValtas(romaiSzam);
                    if (eredmeny != -1) {
                        inputArabSzam.textProperty().set(eredmeny.toString());
                    } else {
                        inputArabSzam.textProperty().set("Hiba!");
                    }
                } else {
                    Integer arabSzam = Integer.parseInt(inputArabSzam.getText());
                    String eredmeny = szamValto.arabValtas(arabSzam);
                    inputRomaiSzam.textProperty().set(eredmeny);
                }
            }
        });
    }
}
