package amigos;

import org.apache.http.HttpStatus;
import org.apache.http.client.fluent.Request;
import org.apache.http.entity.ContentType;


public class MainClass {
	private static String DEFAULTURL = "http://localhost:54321/api/amigo/";
	
	public static void main(String args[]) {
		System.out.println("-------------------------------Listado de amigos-------------------------------");
		System.out.println(listFriends());
		
		System.out.println("-------------------------------Marta (id 2)-------------------------------");
		System.out.println(getFriend(2));
		
		System.out.println("-------------------------------Actualiza por ID-------------------------------");
		System.out.println(updateInfo(2,"4","-5,6686959"));
		System.out.println(getFriend(2));
		
		System.out.println("-------------------------------Actualiza por nombre-------------------------------");
		System.out.println(updateinfo("Marta", "43,5325271", "-5,6686959"));
		System.out.println(getFriend(2));	
	}
	
	/**
	 * 
	 * @return A list of all subscribed friends in a Json code
	 */
	public static String listFriends(){
			try {
				return Request.Get(DEFAULTURL).execute().returnContent().asString();
			} catch (Exception e) {				
				e.printStackTrace();
				return "Error al obtener la lista de amigos";
			} 
	}
	
	/**
	 * 
	 * @param i ID of the selected friend
	 * @return Data of this friend
	 */
	public static String getFriend(int i){
		try {
			return Request.Get(DEFAULTURL+Integer.toString(i)).execute().returnContent().asString();
		} catch (Exception e) {				
			e.printStackTrace();
			return "Error al obtener la lista de amigos";
		} 
	}
	
	/**
	 * Updates the position of a registered member of Amigo's REST application
	 * @param id ID of the selected friend
	 * @param lati latitude of this friend's position
	 * @param string longitude of this friend's position
	 * @return  State of the operation 
	 */
	public static String updateInfo(int id, String lati, String string){
		String info=addInfo(id,lati,string);
		Request put=Request.Put(DEFAULTURL+Integer.toString(id)).bodyString(info, ContentType.create("application/x-www-form-urlencoded"));
		try {
			if(put.execute().returnResponse().getStatusLine().getStatusCode()==HttpStatus.SC_NO_CONTENT){
				return "Done!";
			}else{
				return "Error: Server could not update "+id+"'s possition.";
			}
			
		} catch (Exception e) {
			e.printStackTrace();
			return e.toString();
		} 
	}

	/**
	 * Updates the position of a registered member of Amigo's REST application
	 * @param name of the selected friend
	 * @param lati latitude of this friend's position
	 * @param longi longitude of this friend's position
	 * @return  State of the operation 
	 */
	public static String updateinfo(String name, String lati, String longi){
		String info=addInfo(name,lati,longi);
		Request put=Request.Put(DEFAULTURL+name).bodyString(info, ContentType.create("application/x-www-form-urlencoded"));
		try {
			int code=put.execute().returnResponse().getStatusLine().getStatusCode();
			if(code==HttpStatus.SC_NO_CONTENT){
				return "Done!";
			}else{
				return "HTTP"+code+"\r\nError: Server could not update "+name+"'s possition.";
			}
			
		} catch (Exception e) {
			e.printStackTrace();
			return e.toString();
		} 
	}
	
	/**
	 * Creates the message which is going to be inside the POST/PUT request including the parameters
	 * @param name Amigo's name
	 * @param lati Amigo's latitude
	 * @param longiAmigo's longitude
	 * @return
	 */
	private static String addInfo(String name, String lati, String longi) {
		return "name="+name+"&lati="+lati+"&longi="+longi;
	}

	/**
	 * Creates the message which is going to be inside the POST/PUT request including the parameters
	 * @param id Amigo's identifier-int
	 * @param lati Amigo's latitude-int
	 * @param longi Amigo's longitude-int
	 * @return
	 */
	private static String addInfo(int id, String lati, String longi) {
		return "ID="+Integer.toString(id)+"&lati="+lati+"&longi="+longi;
	}
}
