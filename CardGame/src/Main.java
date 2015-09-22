

public class Main {

	public static void main(String[] args) {
		// Persistência: dados persistidos (não temporário)
		// Gravado e Lido independente da execução do programa
		
		// Padrão de Arquitetura chamado Data Access Object (DAO)
		// Modelo (objeto de negócio, ex.: Aluno, Pedido, Livro, ...)
		
		ContaDAO dao = new ContaDAO();
		PartidaDAO dao2 = new PartidaDAO();
		
		Conta f1 = new Conta();
		f1.setLogin("Abacaxi");
		f1.setPassword("Sci-fi");
		
		Conta c1 = new Conta();
		c1.setLogin("Coco");
		c1.setPassword("1234Cs5");
				
		
		dao.save(f1);
		dao.save(c1);

		
//		dao.delete(f2);
//		dao.delete(f4);
//		dao.delete(f6);
		
		
		Conta a = dao.load("Abacaxi", "Sci-fi");
		System.out.println(a != null);
		System.out.println(a.getLogin().equals("Abacaxi"));
		System.out.println(a.getPassword().equals("Sci-fi"));
		
		Partida p1 = new Partida(1, f1, c1);
		p1.setResult(Resultado.JOGADOR1);
		
		Partida p2 = new Partida(2, f1, c1);
		p2.setResult(Resultado.JOGADOR1);
		
		Partida p3 = new Partida(3, f1, c1);
		p3.setResult(Resultado.JOGADOR2);
		
		Partida p4 = new Partida(4, f1, c1);
		p4.setResult(Resultado.NENHUM);
		
		dao2.save(p1);
		dao2.save(p2);
		dao2.save(p3);
		dao2.save(p4);
		
		System.out.println(f1.getRate());
		System.out.println(c1.getRate());
		
	}

}
