public class SingletonDemo {
        private static volatile SingletonDemo instance = null;
 
        private SingletonDemo() {       }
 
        public static SingletonDemo getInstance() {
                if (instance == null) {
                        synchronized (SingletonDemo .class){
                                if (instance == null) {
                                        instance = new SingletonDemo ();
                                }
                      }
                }
                return instance;
        }
}