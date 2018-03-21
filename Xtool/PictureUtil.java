package com.sdust.Xtool;

import java.io.FileInputStream;
import java.io.FileNotFoundException;

import android.content.CursorLoader;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.provider.MediaStore;
/**
 * 
 * @author Xuwenchao
 *
 */
public class PictureUtil {
	public static Bitmap getPictureByPicPath(String path){
        BitmapFactory.Options options = new BitmapFactory.Options();
        options.inJustDecodeBounds = false;
        try {
        	Bitmap b = BitmapFactory.decodeStream(new FileInputStream(path),null, options);
        	return b;
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
		return null;
	}
}
