import javafx.scene.control.Alert;

import java.io.*;
import java.nio.charset.StandardCharsets;
import java.util.*;

class RomaiSorszam {
    private String romaiSsz;

    public void setRomaiSsz(String ujErtek) {
        this.romaiSsz = ujErtek;
    }

    private static Map<Character, Integer> rómaiMap = new HashMap<Character, Integer>() {{
        put('I', 1);
        put('V', 5);
        put('X', 10);
        put('L', 50);
        put('C', 100);
        put('D', 500);
        put('M', 1000);
    }};

    public String getArabSsz() {
        int ertek = 0;
        String romaiSzam = romaiSsz.replace(".", "");
        for (int i = 0; i < romaiSzam.length(); i++) {
            if (i + 1 < romaiSzam.length() &&
                    rómaiMap.get(romaiSzam.charAt(i)) < rómaiMap.get(romaiSzam.charAt(i + 1))) {
                ertek -= rómaiMap.get(romaiSzam.charAt(i));
            } else {
                ertek += rómaiMap.get(romaiSzam.charAt(i));
            }
        }
        return ertek + ".";
    }

    public RomaiSorszam(String romaiSsz) {
        this.romaiSsz = romaiSsz.toUpperCase();
    }
}

class Donto {
    private RomaiSorszam ssz;
    private String datum;
    private String gyoztes;
    private String eredmeny;
    private String vesztes;
    private String helyszin;
    private String varosAllam;
    private Integer nezoszam;

    public Integer getPontKulonbseg() {
        Integer gyoztesPont = Integer.parseInt(eredmeny.split("-")[0]);
        Integer vesztesPont = Integer.parseInt(eredmeny.split("-")[1]);
        return gyoztesPont - vesztesPont;
    }

    public Integer getNezoszam() {
        return nezoszam;
    }

    public RomaiSorszam getSsz() {
        return ssz;
    }

    public String getDatum() {
        return datum;
    }

    public String getGyoztes() {
        return gyoztes;
    }

    public String getEredmeny() {
        return eredmeny;
    }

    public String getVesztes() {
        return vesztes;
    }

    public String getHelyszin() {
        return helyszin;
    }

    public String getVarosAllam() {
        return varosAllam;
    }

    Donto(String sor) {
        String[] darabolt = sor.split(";");
        this.ssz = new RomaiSorszam(darabolt[0]);
        datum = darabolt[1];
        gyoztes = darabolt[2];
        eredmeny = darabolt[3];
        vesztes = darabolt[4];
        helyszin = darabolt[5];
        varosAllam = darabolt[6];
        nezoszam = Integer.parseInt(darabolt[7]);
    }
}


public class SuperBowl {
    public static void main(String[] args) {
        // 3. Feladat
        List<Donto> dontoLista = new ArrayList<>();
        File inputFile = new File("./SuperBowl.txt");
        try (Scanner scanner = new Scanner(inputFile)) {
            scanner.nextLine();
            while (scanner.hasNextLine()) {
                String aktualisSor = scanner.nextLine();
                Donto donto = new Donto(aktualisSor);
                dontoLista.add(donto);
            }
        } catch (FileNotFoundException exception) {
            System.err.print("Fájl nem található!");
        }

        // 4. feladat
        System.out.println("4. Feladat: Döntő száma: " + dontoLista.size());

        // 5. feladat
        Double pontKulonbsegSum = 0.0;
        for (Donto donto : dontoLista) {
            pontKulonbsegSum += donto.getPontKulonbseg();
        }
        double eredmeny = pontKulonbsegSum / dontoLista.size();
        double kerekitve = Math.round(eredmeny * 10.0) / 10.0;
        System.out.println("5. feladat: Átlagos pontkülönbség: " + kerekitve);

        // 6. feladat
        Donto maxNezoDonto = dontoLista.get(0);
        for (Donto donto : dontoLista) {
            if (donto.getNezoszam() > maxNezoDonto.getNezoszam()) {
                maxNezoDonto = donto;
            }
        }
        System.out.println("6. Feladat: Legmagasabb nézőszám a döntők során:");
        System.out.println("         Sorszám (dátum): " + maxNezoDonto.getSsz().getArabSsz() + " (" + maxNezoDonto.getDatum() + ")");
        System.out.println("         Győztes csapat:" + maxNezoDonto.getGyoztes() + ", szerzett pontok: " + maxNezoDonto.getEredmeny().split("-")[0]);
        System.out.println("         Vesztes csapat:" + maxNezoDonto.getVesztes() + ", szerzett pontok: " + maxNezoDonto.getEredmeny().split("-")[1]);
        System.out.println("         Helyszín: " + maxNezoDonto.getHelyszin());
        System.out.println("         Város, állam: " + maxNezoDonto.getVarosAllam());
        System.out.println("         Nézőszám: " + maxNezoDonto.getNezoszam());

        // 7. Feladat
        BufferedWriter writer;
//      Megoldás Szótárral:
//      Map<String, Integer> szereplesSzamok = new HashMap<>();
        List<String> sorok = new ArrayList<>();
        try {
            writer = new BufferedWriter
                    (new OutputStreamWriter(new FileOutputStream("./SuperBowlNew.txt"), StandardCharsets.UTF_8));
            writer.write("Ssz;Dátum;Győztes;Eredmény;Vesztes;Nézőszám");
            writer.newLine();
            for (Donto donto : dontoLista) {
//                Megoldás Szótárral:
//                String gyoztes = donto.getGyoztes();
//                String vesztes = donto.getVesztes();
//                if (szereplesSzamok.containsKey(gyoztes)) {
//                    szereplesSzamok.put(gyoztes, szereplesSzamok.get(gyoztes) + 1);
//                } else {
//                    szereplesSzamok.put(gyoztes, 1);
//                }
//                if (szereplesSzamok.containsKey(vesztes)) {
//                    szereplesSzamok.put(vesztes, szereplesSzamok.get(vesztes) + 1);
//                } else {
//                    szereplesSzamok.put(vesztes, 1);
//                }
//
//                String gyoztesString = donto.getGyoztes() + "(" + szereplesSzamok.get(donto.getGyoztes()) + ")";
//                String vesztesString = donto.getVesztes() + "(" + szereplesSzamok.get(donto.getVesztes()) + ")";

//              Megoldás szótár nélkül:
                Integer gyoztesDb = 1;
                Integer vesztesDb = 1;
                for(String sor: sorok ){
                    if(sor.contains(donto.getGyoztes())){
                        gyoztesDb ++;
                    }
                    if(sor.contains(donto.getVesztes())){
                        vesztesDb ++;
                    }
                }
                String gyoztesString = donto.getGyoztes() + "(" + gyoztesDb + ")";
                String vesztesString = donto.getVesztes() + "(" + vesztesDb + ")";
                String ujsor = donto.getSsz().getArabSsz() + ";" + donto.getDatum() + ";" + gyoztesString + ";" +
                        donto.getEredmeny() + ";" + vesztesString + ";" + donto.getNezoszam();
                sorok.add(ujsor);
                writer.write(ujsor);
                writer.newLine();
            }
            writer.close();
        } catch (IOException ioException) {
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Mentés");
            alert.setHeaderText("Hiba az állomány írásánál!");
            alert.show();
        }
    }


}
