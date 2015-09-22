
public class Partida  {
	
	//classe que terá informaçoes do jogo
	
	private Conta jog1 = null;
	private Conta jog2 = null;
	private int ID = 0;
	private Resultado result = Resultado.NENHUM;
	
	public int getID() {
		return ID;
	}
	public void setID(int ID) {
		this.ID = ID;
	}
	public Conta getJog1() {
		return jog1;
	}
	public void setJog1(Conta jog1) {
		this.jog1 = jog1;
	}
	public Conta getJog2() {
		return jog2;
	}
	public void setJog2(Conta jog2) {
		this.jog2 = jog2;
	}
	public Resultado getResult() {
		return result;
	}
	public void setResult(Resultado result) {
		this.result = result;
	}

	
	public Partida (int ID, Conta jog1, Conta jog2){
		
		this.ID = ID;
		this.jog1 = jog1;
		this.jog2 = jog2;
		
	}

	
	
	
}
