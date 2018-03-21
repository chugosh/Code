package com.sdust.Xtool;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.UUID;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.util.EntityUtils;

import android.util.Log;
/**
 * 
 * @author Xuwenchao
 *
 */
public class PostUtil {
	private static final int TIME_OUT = 10 * 1000; // 超时时间
	private static final String CHARSET = "utf-8"; // 设置编码
	/**
	 * 发送post请求到服务器
	 * @param map
	 * @param RequestURL
	 * @return 响应数据,否则返回null
	 */
	public static String post(Map<String, Object> map, String RequestURL) {
		String response = null;
		HttpURLConnection conn = null;
		try {
				HttpClient httpClient = new DefaultHttpClient();
				HttpPost httpPost = new HttpPost(RequestURL);
				List<NameValuePair> params = new ArrayList<NameValuePair>();	
				for(String key : map.keySet()){
					Object val = map.get(key);
					if(val instanceof ArrayList){
						for(String s : (ArrayList<String>)val){
							params.add(new BasicNameValuePair(key, s));
						}
					}else{
						params.add(new BasicNameValuePair(key, val.toString()));
					}
				}
				UrlEncodedFormEntity entity = new UrlEncodedFormEntity(params, "utf-8");
				httpPost.setEntity(entity);
				HttpResponse httpResponse = httpClient.execute(httpPost);
				LogUtil.v("responsestate", Integer.toString(httpResponse.getStatusLine().getStatusCode()));
				if (httpResponse.getStatusLine().getStatusCode() == 200) {
					//  请求和响应都成功了
					HttpEntity httpEntity = httpResponse.getEntity();
					response = EntityUtils.toString(httpEntity, "utf-8");
				}
				return response;
		}catch(Exception e){
			e.printStackTrace();
			return null;
		}finally{
			if(conn != null){
				conn.disconnect();
			}
		}
	}
}
