import java.util.ArrayList;

// geral ou abstrato
public interface DAO<T> {
	// método para salvar:
	public void save(T obj);	
	
	// método para excluir:
	public void delete(T obj);
	
	// método para carregar:
	public T load (String ID);
	
	// método para atualizar/alterar registro existente:
	public void update(T obj);
	
	// encontra todos:
	public ArrayList<T> findAll();
}
