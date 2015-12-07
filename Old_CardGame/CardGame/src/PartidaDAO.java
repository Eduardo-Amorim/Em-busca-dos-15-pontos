import java.io.File;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.Scanner;

public class PartidaDAO implements DAO<Partida> {

	private Scanner scan;
	private Scanner scan2;
	
	@Override
	public void save(Partida f) {
		try {
			// diretório
			File dir = new File("partidas");
			if (!dir.exists()) dir.mkdir();
			// arquivo individual
			File arq = new File("partidas/" + f.getID() + ".csv");
			if (arq.exists()) return;
			// gravar os dados
			FileWriter writer = new FileWriter(arq);
			writer.write(f.getID() + ";");
			writer.write(f.getJog1().getLogin() + ";");
			writer.write(f.getJog2().getLogin() + ";");
			writer.write(f.getResult() + "\n");
			// fechar o arquivo
			writer.flush();
			writer.close();
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	@Override
	public void delete(Partida f) {
		try {
			File arq = new File("partidas/" + f.getID() + ".csv");
			// se o arquivo não existe não continua
			if ( ! arq.exists()) return; // pára a execução do método
			// exclui o arquivo
			arq.delete();
		} catch (Exception e) {
			e.printStackTrace();
		}		
	}

	public Partida load(String iD) {		
		try {
			File arq = new File("partidas/" + iD + ".csv");
			
			if ( ! arq.exists()) return null;
			
			scan = new Scanner(arq);
			String linha = scan.nextLine();
			String[] colunas = linha.split(";");
			
			ContaDAO c = new ContaDAO();
			int ID = Integer.parseInt(colunas[0]);
			Conta j1 = c.load(colunas[1]);
			Conta j2 = c.load(colunas[2]);
			Partida f = new Partida(ID,j1 ,j2);
			f.setResult(Resultado.valueOf(colunas[3]));
			return f;
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return null;
	}

	@Override
	public ArrayList<Partida> findAll() {
		ArrayList<Partida> lista = new ArrayList<Partida>();
		try {
			File dir = new File("partidas");		
			File[] arqs = dir.listFiles();
			for (File arq : arqs) { // for each
				scan2 = new Scanner(arq);
				String linha = scan2.nextLine();
				String[] colunas = linha.split(";");
				
				ContaDAO c = new ContaDAO();
				int ID = Integer.parseInt(colunas[0]);
				Conta j1 = c.load(colunas[1]);
				Conta j2 = c.load(colunas[2]);
				Partida f = new Partida(ID,j1 ,j2);
				f.setResult(Resultado.valueOf(colunas[3]));
				lista.add(f);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return lista;
	}
	
	@Override
	public void update(Partida obj) {
		// TODO Auto-generated method stub
		
	}

}
