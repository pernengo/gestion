import java.io.IOException;
import java.net.*;
import java.util.UUID;
public class main {
	public static void main(String[] args)
	{
		
		System.out.println("Comenzando Servidor");
		try {
			
			ServerSocket SS = new ServerSocket(4000);
			System.out.println("Socket Arriba");
			while(true)
			{
			Socket S = SS.accept();
			Hilos hilos = new Hilos();
			hilos.start(java.util.UUID.randomUUID(),S);
			 
			System.out.println("Conectado...");
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			System.out.println(e.getMessage());
			e.printStackTrace();
		}
		
	}

}