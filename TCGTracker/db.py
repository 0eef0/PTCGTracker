import psycopg2

config = {
    'host': 'aws-0-ca-central-1.pooler.supabase.com',
    'port': 5432,
    'database': 'postgres',
    'user': 'postgres.lwwhgmxlwszrqulicand',
    'password': 'EaglesCanFlyBTAI'
}

# Database connection function
def get_db_connection():
    conn = psycopg2.connect(**config)
    return conn