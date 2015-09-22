import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Scanner;

public class ContaDAO implements DAO<Conta> {

	private Scanner scan;
	private Scanner scan2;

	@Override
	public void save(Conta f) {
		try {
			// diretório
			File dir = new File("contas");
			if (!dir.exists()) dir.mkdir();
			// arquivo individual
			File arq = new File("contas/" + f.getLogin() + ".csv");
			if (arq.exists()) return;
			// gravar os dados
			FileWriter writer = new FileWriter(arq);
			writer.write(f.getLogin() + ";");
			writer.write(f.getPassword() + "\n");
			// fechar o arquivo
			writer.flush();
			writer.close();
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	@Override
	public void delete(Conta f) {
		try {
			File arq = new File("contas/" + f.getLogin() + ".csv");
			// se o arquivo não existe não continua
			if ( ! arq.exists()) return; // pára a execução do método
			// exclui o arquivo
			arq.delete();
		} catch (Exception e) {
			e.printStackTrace();
		}		
	}

	public Conta load(String login, String password) {		
		try {
			File arq = new File("contas/" + login + ".csv");
			
			if ( ! arq.exists()) return null;
			
			scan = new Scanner(arq);
			String linha = scan.nextLine();
			String[] colunas = linha.split(";");
			
			Conta f = new Conta();
			f.setLogin(colunas[0]);
			f.setPassword(colunas[1]);
			return f;
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return null;
	}

	public Conta load(String login) {		
		try {
			File arq = new File("contas/" + login + ".csv");
			
			if ( ! arq.exists()) return null;
			
			scan = new Scanner(arq);
			String linha = scan.nextLine();
			String[] colunas = linha.split(";");
			
			Conta f = new Conta();
			f.setLogin(colunas[0]);
			f.setPassword(colunas[1]);
			return f;
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return null;
	}

	@Override
	public ArrayList<Conta> findAll() {
		ArrayList<Conta> lista = new ArrayList<Conta>();
		try {
			File dir = new File("contas");		
			File[] arqs = dir.listFiles();
			for (File arq : arqs) { // for each
				scan2 = new Scanner(arq);
				String linha = scan2.nextLine();
				String[] colunas = linha.split(";");
				
				Conta f = new Conta();
				f.setLogin(colunas[0]);
				f.setPassword(colunas[1]);
				lista.add(f);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return lista;
	}

	@Override
	public void update(Conta obj) {
		// TODO Auto-generated method stub
		
	}

}
