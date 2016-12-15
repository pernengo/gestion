import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;
import java.net.SocketAddress;
import java.util.UUID;

public class Hilos extends Thread {
	
	UUID _UI;
	Socket _MySocket;
	public SocketAddress _SocketAddress;
	public InputStream _InputStream;
	public OutputStream _Outputstream;
	
	
	public void start(UUID MiUI, Socket MySocket) {
		// TODO Auto-generated method stub
		_UI = MiUI;
		_MySocket = MySocket;
		try {
			_Outputstream = _MySocket.getOutputStream();
			_InputStream = _MySocket.getInputStream();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		Enviar("La puta que te pario");
		super.start();
		
		
		
	}
	
	private boolean IsAlive()
	{
		if (
				_MySocket!=null
				)		
		{
			return true;
			
		} else 
		{
			return false;
			
		}
		
	}
	
	
	private String getStringFromInputStream(InputStream is) {

		BufferedReader br = null;
		StringBuilder sb = new StringBuilder();

		String line;
		try {

			br = new BufferedReader(new InputStreamReader(is));
			while ((line = br.readLine()) != null) {
				sb.append(line);
			}

		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			if (br != null) {
				try {
					br.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}

		
		return sb.toString();

	}
	
	public String Recibir()
	{
		if (IsAlive()==true)
		{
			return getStringFromInputStream(_InputStream);
					
		} else 
		{
			return "";
			
		}
		
	}
	
	public boolean Enviar(String _sendString)
	{
		if (IsAlive())
		{
			System.out.println("Esta vivo...");
			try {
				System.out.println("Enviando");
				_Outputstream.write(_sendString.getBytes());
				_Outputstream.flush();
				System.out.println("Todo Bien");
				return true;
			} catch (IOException e) {
				// TODO Auto-generated catch block
				
				e.printStackTrace();
				return false;
			}
			
		} else 
		{
			System.out.println("No esta vivo...");
			return false;
			
		}
	}
	
		public boolean Connect(String IP, int PORT)
		{
					try {
						
						_MySocket = new Socket(IP, PORT);
						_InputStream = _MySocket.getInputStream();
						_Outputstream = _MySocket.getOutputStream();
						return true;
						
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
						return false;
						
					}	
		}
		
	}


