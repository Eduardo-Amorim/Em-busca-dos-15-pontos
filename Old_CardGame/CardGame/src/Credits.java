
public class Credits {

	public static void main(String[] args) throws InterruptedException {
		
		Type("====Creditos====");
		System.out.println();
		Type("MARCOS GOULART");
		System.out.println();
		Type("RAIMUNDO LIMA");
		System.out.println();
		Type("EDUARDO AMORIM");
		System.out.println();
		Type("MARCIO TORRES");
		System.out.println();
		Type("");
	}

	public static void Type(String text) throws InterruptedException{
		char[] textC = text.toCharArray();
		for(int i = 0; i < textC.length; i++){
			System.out.print(textC[i]);
			Thread.sleep(100);
		}
	}

}
