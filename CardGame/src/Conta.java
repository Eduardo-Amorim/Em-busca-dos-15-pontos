import java.util.ArrayList;

public class Conta {

	private String login;
	private String password;
	
	
	public String getLogin() {
		return login;
	}
	public void setLogin(String login) {
		this.login = login;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	@Override
	public String toString() {
		return "Conta [login=" + login + ", password=" + password + "]";
	}
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((login == null) ? 0 : login.hashCode());
		result = prime * result + ((password == null) ? 0 : password.hashCode());
		return result;
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Conta other = (Conta) obj;
		if (login == null) {
			if (other.login != null)
				return false;
		} else if (!login.equals(other.login))
			return false;
		if (password == null) {
			if (other.password != null)
				return false;
		} else if (!password.equals(other.password))
			return false;
		return true;
	}
	
	public double getRate(){ 
		PartidaDAO dao = new PartidaDAO();
		ArrayList<Partida> partidas = dao.findAll();
		int ganhou = 0;
		int total = 0;
		for(int i = 0; i < partidas.size();i++){		
			Partida p = partidas.get(i);
			if(p.getJog1().getLogin().equals(this.login) ||p.getJog2().getLogin().equals(this.login)){
				total++;
				if(p.getResult() == Resultado.EMPATE)ganhou++;
				else if(p.getJog1().getLogin().equals(this.login) && p.getResult() == Resultado.JOGADOR1) ganhou++;
				else if(p.getJog2().getLogin().equals(this.login) && p.getResult() == Resultado.JOGADOR2) ganhou++;
			}
		}
		return (ganhou*100.0)/total;
	}
}
